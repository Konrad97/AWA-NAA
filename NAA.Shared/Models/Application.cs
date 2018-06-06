namespace NAA.Shared.Models
{
    public class Application
    {

        public bool Confirmed => Conformation != null;

        public int Id { get; set; }

        public Applicant Applicant { get; set; }

        public string Uninverity {get; set; }

        public int CourseId { get; set; }

        public string PersonalStatement { get; set; }

        public OfferState OfferState { get; set; }

        public string TeacherReference { get; set; }

        public string TeacherContact { get; set; }

        public Conformation Conformation { get; set; }

    }
}
