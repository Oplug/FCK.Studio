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
    public class MembersService : FCKStudioAppBase
    {
        public readonly IRepository<Members, int> Reposity;
        public MembersService()
        {
            Reposity = new Repository<Members, int>(dbContext);
        }
        public ResultDto<List<Members>> GetListOrderByTime(int PageIndex, int PageSize, Expression<Func<Members, bool>> predicate, string keywords = "", string sort = "", string order = "")
        {
            ResultDto<List<Members>> result = new ResultDto<List<Members>>();
            var query = Reposity.GetAllList(predicate);
            if (!string.IsNullOrEmpty(keywords))
            {
                string[] condis = keywords.Split(',');
                string s = "";
                if (!string.IsNullOrEmpty(condis[0]))
                {
                    s = condis[0];
                    query = query.Where(o => o.Community != null).ToList();
                    query = query.Where(o => o.Community.Contains(s)).ToList();
                }
                if (!string.IsNullOrEmpty(condis[1]))
                {
                    s = condis[1];
                    query = query.Where(o => o.Apartment != null && o.Apartment.Contains(s)).ToList();
                }
                if (!string.IsNullOrEmpty(condis[2]))
                {
                    s = condis[2];
                    query = query.Where(o => o.UnitNum == int.Parse(s)).ToList();
                }
                if (!string.IsNullOrEmpty(condis[3]))
                {
                    s = condis[3];
                    query = query.Where(o => o.DoorCard == int.Parse(s)).ToList();
                }
                if (!string.IsNullOrEmpty(condis[4]))
                {
                    s = condis[4];
                    query = query.Where(o => o.TrueName != null && o.TrueName.Contains(s)).ToList();
                }
                if (!string.IsNullOrEmpty(condis[5]))
                {
                    s = condis[5];
                    query = query.Where(o => o.Phone != null && o.Phone.Contains(s)).ToList();
                }
                if (!string.IsNullOrEmpty(condis[6]))
                {
                    s = condis[6];
                    query = query.Where(o => o.UserID.Contains(s) || o.UserName.Contains(s)).ToList();
                }
            }
            if (sort == "Birthday" && order == "desc")
                query = query.OrderByDescending(o => o.Birthday).ToList();
            if (sort == "Birthday" && order == "asc")
                query = query.OrderBy(o => o.Birthday).ToList();
            if (sort == "TrueName" && order == "desc")
                query = query.OrderByDescending(o => o.TrueName).ToList();
            if (sort == "TrueName" && order == "asc")
                query = query.OrderBy(o => o.TrueName).ToList();
            if (sort == "UnitNum" && order == "desc")
                query = query.OrderByDescending(o => o.UnitNum).ToList();
            if (sort == "UnitNum" && order == "asc")
                query = query.OrderBy(o => o.UnitNum).ToList();
            if (sort == "Age" && order == "desc")
                query = query.OrderByDescending(o => o.Age).ToList();
            if (sort == "Age" && order == "asc")
                query = query.OrderBy(o => o.Age).ToList();
            if (sort == "UserName" && order == "desc")
                query = query.OrderByDescending(o => o.UserName).ToList();
            if (sort == "UserName" && order == "asc")
                query = query.OrderBy(o => o.UserName).ToList();
            if (sort == "UserID" && order == "desc")
                query = query.OrderByDescending(o => o.UserID).ToList();
            if (sort == "UserID" && order == "asc")
                query = query.OrderBy(o => o.UserID).ToList();
            if (sort == "UpdateTime" && order == "desc")
                query = query.OrderByDescending(o => o.UpdateTime).ToList();
            if (sort == "UpdateTime" && order == "asc")
                query = query.OrderBy(o => o.UpdateTime).ToList();
            if (sort == "DoorCard" && order == "desc")
                query = query.OrderByDescending(o => o.DoorCard).ToList();
            if (sort == "DoorCard" && order == "asc")
                query = query.OrderBy(o => o.DoorCard).ToList();
            if (sort == "CreationTime" && order == "desc")
                query = query.OrderByDescending(o => o.CreationTime).ToList();
            if (sort == "CreationTime" && order == "asc")
                query = query.OrderBy(o => o.CreationTime).ToList();
            if (string.IsNullOrEmpty(sort))
                query = query.OrderByDescending(o => o.CreationTime).ToList();
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
