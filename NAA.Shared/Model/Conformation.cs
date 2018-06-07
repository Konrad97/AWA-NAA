using System;

namespace NAA.Shared.Model
{
    public class Conformation
    {

        public int ApplicationId { get; set; }

        public virtual Application Application { get; set; }

        public int ApplicantId { get; set; }

        public virtual  Applicant Applicant { get; set; }

        public DateTime DateTime { get; set; }

    }
}
