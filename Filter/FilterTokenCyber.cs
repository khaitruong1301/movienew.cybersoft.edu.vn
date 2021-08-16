using bookingticketAPI.Reponsitory;
using bookingticketAPI.StatusConstants;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using static bookingticketAPI.Common;

namespace bookingticketAPI.Filter
{
    public class FilterTokenCyber : Attribute,IAuthorizationFilter
    {
        Common commonService = new Common();

        ThongBaoLoi tbl = new ThongBaoLoi();
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            try
            {

                var accessToken = filterContext.HttpContext.Request.Headers["TokenCybersoft"];
                JwtSecurityToken token = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
                string hetHanTime = token.Claims.FirstOrDefault(c => c.Type == "HetHanString").Value;

                if (DateTimes.ConvertDate(hetHanTime) <= DateTime.Now)
                {
                  

                    filterContext.HttpContext.Response.Headers.Add("authToken", accessToken);
                    filterContext.HttpContext.Response.Headers.Add("AuthStatus", "NotAuthorized");

                    filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    filterContext.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Not Authorized";
                    filterContext.Result = new ResponseEntity(StatusCodeConstants.FORBIDDEN, "Token không cybersoft không hợp lệ hoặc đã hết hạn truy cập !", MessageConstant.MESSAGE_ERROR_403);


                }

            }catch (Exception ex)
            {
                filterContext.Result = new ResponseEntity(StatusCodeConstants.FORBIDDEN, "Token không cybersoft không hợp lệ hoặc đã hết hạn truy cập !", MessageConstant.MESSAGE_ERROR_403);
            }

        
        }
    }
    
}
