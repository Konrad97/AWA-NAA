using Naa.Shared.Service;
using NAA.DbAccess;
using NAA.Shared.Model;
using System;
using System.Collections.Generic;

namespace NAA.Service
{
    public class ApplicantService : IApplicantService
    {

        private IApplicantService _service = new ApplicantDataService();

        public void AddApplicant(Applicant applicant)
        {
            _service.AddApplicant(applicant);
        }

        public void EditApplicant(Applicant applicant)
        {
            _service.EditApplicant(applicant);
        }

        public Applicant GetApplicant(int id)
        {
            return _service.GetApplicant(id);
        }

        public Applicant GetApplicant(string email)
        {
            return _service.GetApplicant(email);
        }

        public List<Applicant> GetApplicants()
        {
            return _service.GetApplicants();
        }
    }
}
