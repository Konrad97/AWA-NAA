using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using NAA.Service;
using NAA.Shared.Model;

namespace NAA.Webservice
{
    /// <summary>
    ///     Summary description for ApplicationManagement
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ApplicationManagement : WebService
    {
        private readonly ApplicationService _applicationService = new ApplicationService();

        [WebMethod]
        public List<Application> GetApplications(string university)
        {
            var applications = _applicationService.GetApplicationsByUniversity(university);

            //break cycling reference
            applications.ForEach(x => x.Applicant = null);

            return applications;
        }

        [WebMethod]
        public Application SetApplicationsStatus(string university, int applicationId, OfferState offerState,
            string comment = "")
        {
            var application = _applicationService.GetApplication(applicationId);

            if (!_applicationService.CanEditApplication(university, application, offerState, out var reason))
                throw new SoapException(reason, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri);

            application.OfferState = offerState;
            application.Comment = comment;
            _applicationService.EditApplication(application);

            //break cycling reference
            application.Applicant = null;

            return application;
        }

        [WebMethod]
        public Applicant GetApplicant(string university, int applicantId)
        {
            var application = _applicationService.GeFirmApplication(applicantId);

            if (application != null && application.University == university)
            {
                //break cycling reference
                application.Applicant.Applications = null;

                return application.Applicant;
            }

            throw new SoapException("Applicant has not confiremd an application for your university",
                SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri);
        }
    }
}