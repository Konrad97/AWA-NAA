using System.Collections.Generic;

namespace NAA.Shared.Model
{
    public class Applicant
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual List<Application> Applications { get; set; }

    }
}
