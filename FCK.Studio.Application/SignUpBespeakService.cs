using FCK.Studio.Core;
using FCK.Studio.Repositories;

namespace FCK.Studio.Application
{
    public class SignUpBespeakService: FCKStudioAppBase
    {
        public readonly IRepository<SignUpBespeak, long> Reposity;
        public SignUpBespeakService()
        {
            Reposity = new Repository<SignUpBespeak, long>(dbContext);
        }
    }
}
