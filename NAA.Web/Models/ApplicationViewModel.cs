using NAA.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAA.Web.Models
{
    public class ApplicationViewModel
    {

        public List<Application> Applications { get; set; }

        public int ApplicantId { get; set; }

    }
}