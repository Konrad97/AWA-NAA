using NAA.Shared.Interfaces;

namespace NAA.DbAccess
{
    public static class DataServiceFactory
    {

        private static readonly NaaModel Context = new NaaModel();

        public static IApplicationService GetApplicationService()
        {
            return new ApplicationDataService(Context);
        }

        public static IApplicantService GetApplicantService()
        {
            return new ApplicantDataService(Context);
        }

    }
}
