﻿using FCK.Studio.Application;
using FCK.Studio.Core;
using FCK.Studio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.XTSQ.Controllers
{
    public class ActivityController : BaseController
    {
        // GET: Activity
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult SignUp(long id = 0)
        {
            Articles model = new Articles();
            using (ArticlesService articleS = new ArticlesService())
            {
                var result = articleS.Reposity.Get(id);
                if (result != null)
                {
                    model = result;
                }
            }
            return View(model);
        }
        public ActionResult SignIn(long id = 0)
        {
            Articles model = new Articles();
            using (ArticlesService articleS = new ArticlesService())
            {
                var result = articleS.Reposity.Get(id);
                if (result != null)
                {
                    model = result;
                }
            }
            return View(model);
        }

        public ActionResult Bespeak(long id = 0)
        {
            Articles model = new Articles();
            using (ArticlesService articleS = new ArticlesService())
            {
                var result = articleS.Reposity.Get(id);
                if (result != null)
                {
                    model = result;
                }
            }
            return View(model);
        }

        public JsonResult GetModel(long id)
        {
            SignUpBespeak model = new SignUpBespeak();
            using (SignUpBespeakService subkS = new SignUpBespeakService())
            {
                var result = subkS.Reposity.FirstOrDefault(id);
                if (result != null)
                {
                    model = result;
                }
            }
            return Json(model);
        }
        public JsonResult InsertOrUpdate(SignUpBespeak input)
        {
            Studio.Dto.ResultDto<SignUpBespeak> result = new Studio.Dto.ResultDto<SignUpBespeak>();
            using (SignUpBespeakService subkS = new SignUpBespeakService())
            {
                try
                {
                    ArticlesService articleS = new ArticlesService();
                    var article = articleS.Reposity.Get(input.ActvID);
                    if (article != null)
                    {
                        if (article.SignUpNums < article.LimitSignUp || article.LimitSignUp == 0)
                        {
                            if (article.SignUpEndTime != null && article.SignUpEndTime.Value < DateTime.Now)
                            {
                                result.code = 103;
                            }
                            else
                            {
                                var ishas = subkS.Reposity.GetPageList(1, 0, (o => o.UserName == input.UserName && o.ActvID == input.ActvID)).total;
                                if (ishas > 0)
                                {
                                    result.code = 101;
                                    result.message = "Cannot repeat or make an appointment";
                                }
                                else
                                {
                                    if (input.Id == 0)
                                    {
                                        input.TenantId = tenant.Id;
                                        input.CreationTime = DateTime.Now;
                                    }
                                    input.MemberName = Member != null ? Member.UserName : "";
                                    var data = subkS.Reposity.InsertOrUpdate(input);

                                    article.SignUpNums += 1;
                                    articleS.Reposity.Update(article);

                                    result.code = 100;
                                    result.message = "success";
                                }
                            }
                        }
                        else
                        {
                            result.code = 102;
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.code = 500;
                    result.message = ex.Message;
                }

                return Json(result);
            }
        }

        public JsonResult DoSignIn(string UserName, string Mobile, long ActvID)
        {
            ResultDto<int> result = new ResultDto<int>();
            try
            {
                MembersService userServ = new MembersService();
                SignUpBespeakService signupServ = new SignUpBespeakService();
                var model = signupServ.Reposity.GetAllList(o => o.UserName == UserName && o.Telphone == Mobile && o.ActvID == ActvID).FirstOrDefault();
                if (model != null)
                {
                    if (!model.SignIn)
                    {
                        var user = userServ.Reposity.GetAllList(o => o.Mobile == Mobile).FirstOrDefault();
                        if (user != null)
                        {
                            result.code = 100;
                            result.message = "ok";
                            user.Points += 10;
                            userServ.Reposity.Update(user);

                            model.SignIn = true;
                            signupServ.Reposity.Update(model);
                        }
                        else
                        {
                            result.code = 500;
                            result.message = "签到失败！签到手机号与用户注册手机号不符！";
                        }
                    }
                    else
                    {
                        result.code = 500;
                        result.message = "对不起，您已经签到过了！";
                    }
                }
                else
                {
                    result.code = 500;
                    result.message = "签到失败！未找到预约信息！";
                }
                userServ.Dispose();
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.message = ex.Message;
            }
            return Json(result);
        }
    }
}