using System;
using System.Collections.Generic;
using Naa.Shared.Service;
using NAA.DbAccess;
using NAA.Shared.Model;

namespace NAA.Service
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantService _service = new ApplicantDataService();

        public void AddApplicant(Applicant applicant)
        {
            if (!CannAddApplicant(applicant, out var reason)) throw new InvalidOperationException(reason);

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

        public bool CannAddApplicant(Applicant applicant, out string reason)
        {
            reason = null;

            if (string.IsNullOrEmpty(applicant.Email))
            {
                reason = "Email is required";
                return false;
            }

            var existing = _service.GetApplicant(applicant.Email);

            if (existing != null)
            {
                reason = "Email is already in use";
                return false;
            }

            return true;
        }
    }
}