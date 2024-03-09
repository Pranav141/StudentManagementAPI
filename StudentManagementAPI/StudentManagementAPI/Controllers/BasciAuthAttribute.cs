//BasicAuthAttribute
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Net;
using System.Security.Principal;
using System.Text;

namespace StudentManagementAPI.Controllers
{
    internal class BasicAuthAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Headers.Authorization == StringValues.Empty)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.HttpContext.Response.Headers.TryAdd("WWW-Authenticate", "Basic");
                context.Result = new ContentResult
                {
                    //StatusCode = (int)HttpStatusCode.Unauthorized,
                    Content = "Please Provide Authorization Header"
                };
            }
            else
            {
                string[] base64coded = context.HttpContext.Request.Headers.Authorization.ToString().Split(' ');
                string decode = Encoding.UTF8.GetString(Convert.FromBase64String(base64coded[1]));
                string[] userpword = decode.Split(':');
                string username = userpword[0];
                string password = userpword[1];
                if (username == "Pranav" && password == "12345")
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), ["Admin"]);
                }
                else
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.HttpContext.Response.Headers.TryAdd("WWW-Authenticate", "Basic");
                    context.Result = new ContentResult
                    {
                        StatusCode = (int)HttpStatusCode.Unauthorized,
                        Content = "Please Provide Valid Credentials"
                    };
                }
            }

        }
    }
}