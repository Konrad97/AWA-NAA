using System;
using System.Collections.Generic;
using System.Text;
using NAA.DbAccess;
using NAA.Shared.Interfaces;
using NAA.Shared.Models;

namespace NAA.Service
{
    class ApplicantService : IApplicantService
    {

        private readonly IApplicantService _dataService = DataServiceFactory.GetApplicantService();


        public Applicant GetApplicant(string email)
        {
            return _dataService.GetApplicant(email);
        }

        public void AddApplicant(Applicant applicant)
        {
            _dataService.AddApplicant(applicant);
        }

        public void EditApplicant(Applicant applicant)
        {
            _dataService.EditApplicant(applicant);
        }
    }
}
