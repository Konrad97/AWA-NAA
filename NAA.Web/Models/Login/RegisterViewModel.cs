namespace NAA.Web.Models.Login
{
    public class RegisterViewModel
    {

        public Shared.Model.Applicant Applicant { get; set; }

        public bool CannRegisert { get; set; } = true;

        public string CannNotRegitserReason { get; set; }

    }
}