using NAA.Service;
using NAA.Shared.Model;
using NAA.Shared.Service;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;

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

        private readonly IApplicationService _service = new ApplicationService();

        [WebMethod]
        public List<Application> GetApplications(string university)
        {
            var data = _service.GetApplicationsByUniversity(university);

            return data;
        }

        [WebMethod]
        public Application SetApplicationsStatus(string university, int applicationId, OfferState offerState, string comment = "")
        {
            var application = _service.GetApplication(applicationId);

            if (application == null)
                throw new SoapException("Application was not Found.", SoapException.ClientFaultCode);

            if (application.University != university)
                throw new SoapException("Permission Denied.", SoapException.ClientFaultCode);

            if (application.OfferState != OfferState.Conditional && application.OfferState != OfferState.Pending)
                throw new SoapException("Offerstate can not be modified.", SoapException.ClientFaultCode);

            if (application.OfferState == OfferState.Conditional && offerState != OfferState.Unconditional)
                throw new SoapException("Conditional Offer State can only be set to Unconditional.",
                    SoapException.ClientFaultCode);

            application.OfferState = offerState;
            application.Comment = comment;
            _service.EditApplication(application);

            return application;
        }
    }
}
