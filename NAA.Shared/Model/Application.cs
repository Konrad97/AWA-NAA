namespace NAA.Shared.Model
{
    public class Application
    {

        public bool Confirmed => Conformation != null;

        public int Id { get; set; }

        public int ApplicantId { get; set; }

        public virtual Applicant Applicant { get; set; }

        public string University {get; set; }

        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public string PersonalStatement { get; set; }

        public OfferState OfferState { get; set; } = OfferState.Pending;

        public string Comment { get; set; }

        public string TeacherReference { get; set; }

        public string TeacherContact { get; set; }

        public virtual Conformation Conformation { get; set; }

    }
}
