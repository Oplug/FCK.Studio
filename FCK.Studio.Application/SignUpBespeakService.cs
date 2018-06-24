using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FCK.Studio.Core;
using FCK.Studio.Dto;
using FCK.Studio.Repositories;
using System.Linq;
using System.Data.Entity;

namespace FCK.Studio.Application
{
    public class SignUpBespeakService: FCKStudioAppBase
    {
        public readonly IRepository<SignUpBespeak, long> Reposity;
        public SignUpBespeakService()
        {
            Reposity = new Repository<SignUpBespeak, long>(dbContext);
        }

        public ResultDto<List<SignUpBespeak>> GetListOrderByTime(int PageIndex, int PageSize, Expression<Func<SignUpBespeak, bool>> predicate)
        {
            ResultDto<List<SignUpBespeak>> result = new ResultDto<List<SignUpBespeak>>();
            var query = Reposity.GetAllList(predicate);
            query = query.OrderByDescending(entity => entity.CreationTime).ToList();
            result.total = query.Count;
            if (PageSize > 0)
            {
                result.pages = (result.total + PageSize - 1) / PageSize;
                query = query.Skip(PageSize * (PageIndex - 1)).Take(PageSize).ToList();
            }
            result.datas = query;
            return result;
        }
    }
}
