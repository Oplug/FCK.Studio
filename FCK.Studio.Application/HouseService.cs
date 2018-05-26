using System;
using FCK.Studio.Core;
using FCK.Studio.Repositories;

namespace FCK.Studio.Application
{
    public class HouseService: FCKStudioAppBase
    {
        public readonly IRepository<Houses, int> Reposity;
        public HouseService()
        {
            Reposity = new Repository<Houses, int>(dbContext);
        }
    }
}
