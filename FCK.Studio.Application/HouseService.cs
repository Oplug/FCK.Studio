using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FCK.Studio.Core;
using FCK.Studio.Dto;
using FCK.Studio.Repositories;
using System.Linq;
using System.Data.Entity;

namespace FCK.Studio.Application
{
    public class HouseService: FCKStudioAppBase
    {
        public readonly IRepository<Houses, int> Reposity;
        public HouseService()
        {
            Reposity = new Repository<Houses, int>(dbContext);
        }
        public ResultDto<List<Houses>> GetListOrderByID(int PageIndex, int PageSize, Expression<Func<Houses, bool>> predicate, string keywords = "")
        {
            ResultDto<List<Houses>> result = new ResultDto<List<Houses>>();
            var query = Reposity.GetAllList(predicate);
            if (!string.IsNullOrEmpty(keywords))
            {
                string[] condis = keywords.Split(',');
                string s = "";
                if (!string.IsNullOrEmpty(condis[0]))
                {
                    s = condis[0];
                    query = query.Where(o => o.Category.CategoryName.Contains(s)).ToList();
                }
                if (!string.IsNullOrEmpty(condis[1]))
                {
                    s = condis[1];
                    query = query.Where(o => o.HouseName.Contains(s)).ToList();
                }
                if (!string.IsNullOrEmpty(condis[2]))
                {
                    s = condis[2];
                    query = query.Where(o => o.UnitNum != null && o.UnitNum.Contains(s)).ToList();
                }
                if (!string.IsNullOrEmpty(condis[3]))
                {
                    s = condis[3];
                    query = query.Where(o => o.DoorCard != null && o.DoorCard.Contains(s)).ToList();
                }
                if (!string.IsNullOrEmpty(condis[4]))
                {
                    s = condis[4];
                    query = query.Where(o => o.HouseType.Contains(s)).ToList();
                }
                if (!string.IsNullOrEmpty(condis[5]))
                {
                    s = condis[5];
                    query = query.Where(o => o.Owner != null && o.Owner.Contains(s)).ToList();
                }
                if (!string.IsNullOrEmpty(condis[6]))
                {
                    s = condis[6];
                    query = query.Where(o => o.ShortChar1 != null && o.ShortChar1.Contains(s)).ToList();
                }
                if (!string.IsNullOrEmpty(condis[7]))
                {
                    s = condis[6];
                    query = query.Where(o => o.ShortChar2 != null && o.ShortChar2.Contains(s)).ToList();
                }
            }
            query = query.OrderByDescending(entity => entity.Id).ToList();
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
