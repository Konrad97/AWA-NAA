using System.Collections.Generic;
using NAA.Shared.Model;

namespace Naa.Shared.Service
{
    public interface IApplicantService
    {
        List<Applicant> GetApplicants();

        Applicant GetApplicant(int id);

        Applicant GetApplicant(string email);

        void AddApplicant(Applicant applicant);

        void EditApplicant(Applicant applicant);
    }
}