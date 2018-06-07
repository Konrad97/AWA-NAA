using Naa.Shared.Service;
using NAA.Shared.Model;

namespace NAA.DbAccess
{
    public class ConformationService : IConformationService
    {

        private readonly NaaDbModel _context = new NaaDbModel();

        public Conformation GetConformation(int applicantId)
        {
            return _context.Conformations.Find(applicantId);
        }
    }
}
