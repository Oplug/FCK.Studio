using FCK.Studio.Core;
using FCK.Studio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCK.Studio.Application
{
    public class DemdInfoService: FCKStudioAppBase
    {
        public readonly IRepository<DemdInfo, long> Reposity;
        public DemdInfoService()
        {
            Reposity = new Repository<DemdInfo, long>(dbContext);
        }
    }
}
