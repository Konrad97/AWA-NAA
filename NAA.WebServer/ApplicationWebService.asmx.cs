using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using NAA.Service;
using NAA.Shared.Model;
using NAA.Shared.Service;

namespace NAA.WebServer
{

    /// <summary>
    /// With this webservice you can check applications to your university and manage their state.
    /// </summary>
    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // Wenn der Aufruf dieses Webdiensts aus einem Skript zulässig sein soll, heben Sie mithilfe von ASP.NET AJAX die Kommentarmarkierung für die folgende Zeile auf. 
    // [System.Web.Script.Services.ScriptService]

    public class ApplicationWebService : System.Web.Services.WebService
    {

        readonly IApplicationService _service = new ApplicationService();

        [WebMethod]
        public List<Application> GetApplications(string university)
        {
            return _service.GetApplicationsByUniversity(university);
        }

        [WebMethod]
        public Application SetApplicationsStatus(string university, int applicationId, OfferState offerState)
        {
            Application application;
            try
            {
                 application = _service.GetApplication(applicationId);
            }
            catch (ArgumentNullException e)
            {
                throw new SoapException("Application was not Found.", SoapException.ClientFaultCode);
            }

            if (application.University != university)
            {
                throw new SoapException("Permission Denied.", SoapException.ClientFaultCode);
            }

            if (application.OfferState != OfferState.Conditional || application.OfferState != OfferState.Pending)
            {
                throw new SoapException("Offerstate can not be modified.", SoapException.ClientFaultCode);
            }

            if (application.OfferState == OfferState.Conditional && offerState != OfferState.Unconditional)
            {
                throw new SoapException("Conditional Offer State can only be set to Unconditional.", SoapException.ClientFaultCode);
            }

            application.OfferState = offerState;
            _service.EditApplication(application);

            return application;
        }
    }
}
