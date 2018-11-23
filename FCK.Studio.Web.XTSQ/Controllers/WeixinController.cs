using FCK.Studio.Application;
using FCK.Studio.Dto;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using Senparc.Weixin.MP.CommonAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.XTSQ.Controllers
{
    public class WeixinController : BaseController
    {
        // GET: Weixin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(string signature, string timestamp, string nonce, string echostr)
        {
            if (CheckSignature.Check(signature, timestamp, nonce, wx_token))
            {
                return Content(echostr);
            }
            else
            {
                return Content("failed:" + signature + "," + Senparc.Weixin.MP.CheckSignature.GetSignature(timestamp, nonce, wx_token) + "。如果您在浏览器中看到这条信息，表明此Url可以填入微信后台。");
            }
        }

        public ActionResult WeixinAuth()
        {
            Core.Members user = new Core.Members();
            try
            {
                string code = Request.QueryString["code"];
                OAuthAccessTokenResult result = OAuthApi.GetAccessToken(tenant.WXAppId, tenant.WXAppSecret, code);
                if (result != null)
                {
                    if (result.errcode.ToString() == "请求成功")
                    {
                        string openId = result.openid;
                        string access_token = result.access_token;

                        OAuthUserInfo userInfo = OAuthApi.GetUserInfo(access_token, openId);
                        if (userInfo != null)
                        {
                            MembersService ObjServ = new MembersService();
                            var model = ObjServ.Reposity.GetAllList(o => o.WXOpenID == userInfo.openid).FirstOrDefault();
                            if (model == null)
                            {
                                Random rand = new Random();
                                int rank = rand.Next(1, 8);
                                user.UserName = rand.Next(10000, 999999).ToString();
                                user.NickName = userInfo.nickname;
                                user.WXOpenID = userInfo.openid;
                                user.Password = MD5("123456");                                
                                user.Photo = "/Content/dist/img/user" + rank.ToString() + ".jpg";
                                user.CreationTime = DateTime.Now;
                                user.TenantId = tenant.Id;
                                user.IsReger = true;
                                user.Email = "00";
                                user.UserID = "00";
                                ObjServ.Reposity.Insert(user);
                                SetCookie("MemberId", user.Id.ToString(), 5);
                                SetCookie("UserName", HttpUtility.UrlEncode(user.UserName, encode), 5);
                            }
                            else
                            {
                                user = model;
                                SetCookie("MemberId", model.Id.ToString(), 5);
                                SetCookie("UserName", HttpUtility.UrlEncode(model.UserName, encode), 5);
                            }
                            ObjServ.Dispose();
                        }
                    }
                }
            }
            catch (Exception e) { }
            return View(user);
        }

        /// <summary>
        /// 发送微信模板消息
        /// </summary>
        /// <param name="str_first"></param>
        /// <param name="keyword1"></param>
        /// <param name="keyword2"></param>
        /// <param name="remark"></param>
        /// <param name="templateId"></param>
        /// <param name="linkUrl"></param>
        /// <param name="openId">接收用户openid</param>
        /// <returns></returns>
        public ResultDto<string> SendWxTempMessage(string str_first, string keyword1, string keyword2, string remark, string templateId, string linkUrl, string openId)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                //根据appId判断获取    
                if (!AccessTokenContainer.CheckRegistered(tenant.WXAppId))
                {
                    AccessTokenContainer.Register(tenant.WXAppId, tenant.WXAppSecret);
                }
                string access_token = AccessTokenContainer.GetAccessTokenResult(tenant.WXAppId).access_token;

                var templateData = new AttendanceTemplateData()
                {
                    first = new TemplateDataItem(str_first, "#000000"),
                    keyword1 = new TemplateDataItem(keyword1, "#000000"),
                    keyword2 = new TemplateDataItem(keyword2, "#000000"),
                    remark = new TemplateDataItem(remark, "#000000")
                };

                SendTemplateMessageResult sendResult = TemplateApi.SendTemplateMessage(access_token, openId, templateId, "", linkUrl, templateData);

                //发送成功  
                if (sendResult.errcode.ToString() == "请求成功")
                {
                    result.code = 100;
                    result.message = "发送成功";
                }
                else
                {
                    result.code = 102;
                    result.message = sendResult.errmsg;
                }
            }
            catch (Exception e)
            {
                result.code = 102;
                result.message = e.Message;
            }

            return result;
        }
    }

    public class AttendanceTemplateData
    {
        public TemplateDataItem first { get; set; }
        public TemplateDataItem keyword1 { get; set; }
        public TemplateDataItem keyword2 { get; set; }
        public TemplateDataItem remark { get; set; }
    }
}