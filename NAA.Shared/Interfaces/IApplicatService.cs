using NAA.Shared.Models;

namespace NAA.Shared.Interfaces
{
    public interface IApplicatService
    {

        Applicant GetApplicant(string email);

        void AddApplicant(Applicant applicant);

        void EditApplicant(Applicant applicant);

    }
}
