using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Naa.Shared.Service;
using NAA.Service;
using NAA.Shared.Model;

namespace NAA.WebServer
{

    /// <summary>
    /// Zusammenfassungsbeschreibung für WebService
    /// </summary>
    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // Wenn der Aufruf dieses Webdiensts aus einem Skript zulässig sein soll, heben Sie mithilfe von ASP.NET AJAX die Kommentarmarkierung für die folgende Zeile auf. 
    // [System.Web.Script.Services.ScriptService]

    public class ApplicationService : System.Web.Services.WebService
    {

        IApplicantService _service = new ApplicantService();

        [WebMethod]
        public List<Application> GetApplications(string university)
        {
            
        }
    }
}
