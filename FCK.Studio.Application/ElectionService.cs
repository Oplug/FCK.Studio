using System;
using FCK.Studio.Core;
using FCK.Studio.Repositories;

namespace FCK.Studio.Application
{
    public class ElectionService: FCKStudioAppBase
    {
        public readonly IRepository<Election, int> Reposity;
        public readonly IRepository<ElectionHead, int> ReposityHD;
        public ElectionService()
        {
            Reposity = new Repository<Election, int>(dbContext);
            ReposityHD = new Repository<ElectionHead, int>(dbContext);
        }
    }
}
