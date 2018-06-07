using System;
using System.Collections.Generic;
using System.Text;
using NAA.DbAccess;
using NAA.Shared.Service;
using NAA.Shared.Model;
using System.Linq;
using Naa.Shared.Service;

namespace NAA.Service
{
    public class ApplicationService : IApplicationService
    {
        private IApplicationService _applicationService = new ApplicationDataService();
        private IConformationService  _conformationService = new ConformationService();
        private IApplicantService _applicantService = new ApplicantDataService();

        public void AddApplication(Application application)
        {

            if(!CanAddApplication(application.ApplicantId, out string reason))
            {
                throw new InvalidOperationException(reason);
            }

            if (!CanAddApplication(application, out reason))
            {
                throw new InvalidOperationException(reason);
            }

            _applicationService.AddApplication(application);
        }

        public void EditApplication(Application application)
        {
            _applicationService.EditApplication(application);
        }

        public void DeleteApplication(Application application)
        {
            _applicationService.DeleteApplication(application);
        }

        public List<Application> GetApplicationsByApplicantId(int applicatId)
        {
            return _applicationService.GetApplicationsByApplicantId(applicatId);
        }

        public List<Application> GetApplicationsByUniversity(string university)
        {
            return _applicationService.GetApplicationsByUniversity(university);
        }

        public List<Application> GetApplications()
        {
            return _applicationService.GetApplications();
        }

        public Application GetApplication(int id)
        {
            return _applicationService.GetApplication(id);
        }

        public bool CanAddApplication(int applicantId, out string reason)
        {
            reason = null;

            int count = _applicationService.GetApplicationsByApplicantId(applicantId).Where(x => x.OfferState != OfferState.Rejected).Count();
            
            if (count > 4)
            {
                reason = "Applicant can only have up to 5 applications";
                return false;
            }

            bool hasConfirmed = _conformationService.GetConformation(applicantId) != null;

            if (hasConfirmed)
            {
                reason = "Applicant allready confirmed a application";
                return false;
            }

            return true;
        }

        public bool CanAddApplication(Application application, out string reason)
        {
            reason = null;

            int applicantId = application.Applicant != null ? application.Applicant.Id : application.ApplicantId;

            if (applicantId == 0)
            {
                reason = "Applicant isn't set";
                return false;
            }

            var existing = GetApplicationsByUniversity(application.University)
                .FirstOrDefault(x => x.CourseId == application.CourseId);
   
            if (existing != null)
            {
                if (existing.OfferState == OfferState.Rejected)
                {
                    reason = "You were rejected for this course";
                }
                else
                {
                    reason = "You already applied for this course";
                }

                return false;
            }

            return true;
        }

    }
}
