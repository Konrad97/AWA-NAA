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

        private readonly ApplicationService _service = new ApplicationService();

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

            if (!_service.CanEditApplication(university, application, offerState, out string reason))
            {
                throw new SoapException(reason, SoapException.ClientFaultCode);
            }

            application.OfferState = offerState;
            application.Comment = comment;
            _service.EditApplication(application);

            return application;
        }
    }
}
