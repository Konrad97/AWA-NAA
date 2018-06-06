using NAA.Shared.Models;

namespace NAA.Shared.Interfaces
{
    public interface IApplicantService
    {

        Applicant GetApplicant(string email);

        void AddApplicant(Applicant applicant);

        void EditApplicant(Applicant applicant);

    }
}
