using NAA.Shared.Model;

namespace NAA.Web.Models.Login
{
    public class RegisterViewModel
    {
        public Applicant Applicant { get; set; }

        public bool CannRegisert { get; set; } = true;

        public string CannNotRegitserReason { get; set; }
    }
}