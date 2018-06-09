﻿using System;
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
    public class ArticlesService : FCKStudioAppBase, IArticlesService
    {
        public readonly IRepository<Articles, long> Reposity;
        public ArticlesService()
        {
            Reposity = new Repository<Articles, long>(dbContext);
        }
        public ResultDto<List<Articles>> GetArticleWithCate(int PageIndex, int PageSize)
        {
            ResultDto<List<Articles>> result = new ResultDto<List<Articles>>();
            var query = Reposity.GetPageList(PageIndex, PageSize);
            result.pages = query.pages;
            result.total = query.total;
            result.datas = query.datas.AsQueryable()
                .OrderByDescending(entity => entity.CreationTime)
                .Include(entity => entity.CategoryId)
                .ToList();
            return result;
        }
        public ResultDto<List<Articles>> GetArticleWithCate(int PageIndex, int PageSize, int TenantId)
        {
            ResultDto<List<Articles>> result = new ResultDto<List<Articles>>();
            var query = Reposity.GetPageList(PageIndex, PageSize, (o => o.TenantId == TenantId));
            result.pages = query.pages;
            result.total = query.total;
            result.datas = query.datas.AsQueryable()
                .OrderByDescending(entity => entity.CreationTime)
                .Include(entity => entity.CategoryId)
                .ToList();
            return result;
        }
        public async Task<ResultDto<List<Articles>>> GetArticleWithCateSync(int PageIndex, int PageSize, Expression<Func<Articles, bool>> predicate)
        {
            ResultDto<List<Articles>> result = new ResultDto<List<Articles>>();
            var query = await Reposity.GetPageListAsync(PageIndex, PageSize, predicate);
            result.pages = query.pages;
            result.total = query.total;
            result.datas = query.datas.AsQueryable()
                .OrderByDescending(entity => entity.CreationTime)
                .Include(entity => entity.CategoryId)
                .ToList();
            return result;
        }

        public ResultDto<List<Articles>> GetListOrderByTime(int PageIndex, int PageSize, Expression<Func<Articles, bool>> predicate)
        {
            ResultDto<List<Articles>> result = new ResultDto<List<Articles>>();
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
