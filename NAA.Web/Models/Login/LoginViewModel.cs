using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAA.Web.Models.Login
{
    public class LoginViewModel
    {
        public string Email { get; set; }

        public bool InvalidEmail { get; set; }

    }
}