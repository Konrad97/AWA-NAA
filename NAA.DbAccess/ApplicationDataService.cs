﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NAA.Shared.Model;
using NAA.Shared.Service;

namespace NAA.DbAccess
{
    public class ApplicationDataService : IApplicationService
    {
        private readonly NaaDbModel _context = new NaaDbModel();

        public void AddApplication(Application application)
        {
            _context.Applications.Add(application);
            _context.SaveChanges();
        }

        public void EditApplication(Application application)
        {
            var current = _context.Applications.Find(application.Id);
            _context.Entry(current).CurrentValues.SetValues(application);
            _context.SaveChanges();
        }

        public void DeleteApplication(Application application)
        {
            _context.Applications.Remove(application);
            _context.SaveChanges();
        }

        public List<Application> GetApplicationsByApplicantId(int applicantId)
        {
            var data = _context.Applications.Where(x => x.Applicant.Id == applicantId).Include(x => x.Applicant)
                .ToList();
            return data;
        }

        public List<Application> GetApplicationsByUniversity(string university)
        {
            return _context.Applications.Where(x => x.University == university).Include(x => x.Applicant).ToList();
        }

        public List<Application> GetApplications()
        {
            return _context.Applications.Include(x => x.Applicant).ToList();
        }

        public Application GetApplication(int id)
        {
            return _context.Applications.Include(x => x.Applicant).SingleOrDefault(x => x.Id == id);
        }
    }
}