using System;

namespace NAA.Shared.Model
{
    public class Conformation
    {

        public int Id { get; set; }

        public virtual  Applicant Applicant { get; set; }

        public virtual Application Application { get; set; }

        public DateTime DateTime { get; set; }

    }
}
