using NAA.Service;
using NAA.Shared.Model;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;

namespace NAA.Webservice
{
    /// <summary>
    /// Summary description for ApplicationManagement
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ApplicationManagement : WebService
    {

        private readonly ApplicationService _applicationService = new ApplicationService();
        private readonly ApplicantService _applicantService = new ApplicantService();

        [WebMethod]
        public List<Application> GetApplications(string university)
        {
            var data = _applicationService.GetApplicationsByUniversity(university);

            return data;
        }

        [WebMethod]
        public Application SetApplicationsStatus(string university, int applicationId, OfferState offerState, string comment = "")
        {

            var application = _applicationService.GetApplication(applicationId);

            if (!_applicationService.CanEditApplication(university, application, offerState, out string reason))
            {
                throw new SoapException(reason, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri);
            }

            application.OfferState = offerState;
            application.Comment = comment;
            _applicationService.EditApplication(application);

            return application;
        }

        [WebMethod]
        public Applicant GetApplicant(string university, int applicantId)
        {
            var application = _applicationService.GeFirmApplication(applicantId);
            var applicant = _applicantService.GetApplicant(application.ApplicantId);

            if (application != null && application.University == university)
            {
                return applicant;
            }

            throw new SoapException("Applicant has not confiremd an application for your university", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri);
        }

    }
}
