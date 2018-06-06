using NAA.Shared.Interfaces;

namespace NAA.DbAccess
{
    public class DataServiceFactory
    {

        private readonly NaaModel _context = new NaaModel();

        public IApplicationService GetApplicatService()
        {
            return new ApplicationDataService(_context);
        }

        public IApplicantService GetApplicantService()
        {
            return new ApplicantDataService(_context);
        }


    }
}
