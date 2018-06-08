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
        private IApplicantService _applicantService = new ApplicantDataService();

        public void AddApplication(Application application)
        {

            if(!CanAddApplication(application.ApplicantId, out string reason))
            {
                throw new InvalidOperationException(reason);
            }

            if (!CanAddApplication(application.ApplicantId, application.University, application.CourseId, out reason))
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

        public Application GeFirmApplication(int applicantId)
        {
            return _applicationService.GetApplicationsByApplicantId(applicantId).FirstOrDefault(x => x.Confirmed);
        }

        public Application GetApplication(int id)
        {
            return _applicationService.GetApplication(id);
        }

        public bool CanAddApplication(int applicantId, out string reason)
        {
            reason = null;

            var applications = _applicationService.GetApplicationsByApplicantId(applicantId);
            
            if (applications.Count > 4)
            {
                reason = "Applicant can only have up to 5 applications";
                return false;
            }

            bool hasConfirmed = applications.Any(x => x.Confirmed);

            if (hasConfirmed)
            {
                reason = "Applicant allready confirmed an application";
                return false;
            }

            return true;
        }

        public bool CanEditApplication(int applicationId)
        {
            var application = _applicationService.GetApplication(applicationId);

            return application.OfferState == OfferState.Pending;
        }

        public void ConfirmApplication(int applicationId)
        {
            if (!CanAcceptApplication(applicationId))
            {
                throw new InvalidOperationException("Application can not be confirmed");
            }

            var application = _applicationService.GetApplication(applicationId);

            application.Confirmed = true;

            _applicationService.EditApplication(application);
        }

        public bool CanAcceptApplication(int applicationId)
        {
            var application = _applicationService.GetApplication(applicationId);

            if(application.OfferState == OfferState.Conditional || application.OfferState == OfferState.Unconditional)
            {
                var applications = _applicationService.GetApplicationsByApplicantId(application.ApplicantId);
                bool hasConfirmed = applications.Any(x => x.Confirmed);

                if (hasConfirmed)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        public bool CanAddApplication(int applicantId, string university, int courseId, out string reason)
        {
            reason = null;

            var existing = GetApplicationsByUniversity(university)
                .FirstOrDefault(x => x.CourseId == courseId && x.ApplicantId == applicantId);
   
            if (existing != null)
            {
                if (existing.OfferState == OfferState.Rejected)
                {
                    reason = "You were rejected from this course";
                }
                else
                {
                    reason = "You already applied for this course";
                }

                return false;
            }

            return true;
        }

        public bool CanEditApplication(string university, Application application, OfferState offerState, out string reason)
        {
            reason = null;

            if (application == null)
            {
                reason = "Application was not Found.";
                return false;
            }

            if (application.University != university)
            {
                reason = "Permission Denied.";
                return false;
            }

            if (application.OfferState != OfferState.Conditional && application.OfferState != OfferState.Pending)
            {
                reason = "Offerstate can not be modified.";
                return false;
            }

            if (application.OfferState == OfferState.Conditional && offerState != OfferState.Unconditional)
            {
                reason = "Conditional Offer State can only be set to Unconditional.";
                return false;
            }

            return true;
        }
    }
}
