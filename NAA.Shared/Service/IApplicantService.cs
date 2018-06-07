using NAA.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
