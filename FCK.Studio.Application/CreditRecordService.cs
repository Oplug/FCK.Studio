using FCK.Studio.Core;
using FCK.Studio.Repositories;

namespace FCK.Studio.Application
{
    public class CreditRecordService: FCKStudioAppBase
    {
        public readonly IRepository<CreditRecords, int> Reposity;
        public CreditRecordService()
        {
            Reposity = new Repository<CreditRecords, int>(dbContext);
        }
    }
}
