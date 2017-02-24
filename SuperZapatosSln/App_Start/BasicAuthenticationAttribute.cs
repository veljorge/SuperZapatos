using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using SuperZapatos.Dtos;

namespace SuperZapatosSln.App_Start
{
    public class BasicAuthenticationAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {

            ErrorResponse error = new ErrorResponse("Not Authorized", 401, false);
            try
            {
                if (actionContext.Request.Headers.Authorization == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                                                                                      error,
                                                                                      actionContext.ControllerContext.Configuration.Formatters.JsonFormatter
                                                                                      );
                }
                else
                {
                    var httpRequestHeader = actionContext.Request.Headers.Authorization.Parameter;
                    httpRequestHeader = Encoding.UTF8.GetString(Convert.FromBase64String(httpRequestHeader));

                    string[] httpRequestHeaderValues = httpRequestHeader.Split(':');
                    string username = httpRequestHeaderValues[0]; //Encoding.UTF8.GetString(Convert.FromBase64String(httpRequestHeaderValues[0]));
                    string password = httpRequestHeaderValues[1];//Encoding.UTF8.GetString(Convert.FromBase64String(httpRequestHeaderValues[1]));

                    if (!(username.Equals("my_user") && password.Equals("my_password")))
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                                                                                      error,
                                                                                      actionContext.ControllerContext.Configuration.Formatters.JsonFormatter
                                                                                      );
                    }
                }
            }
            catch
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                                                                                      error,
                                                                                      actionContext.ControllerContext.Configuration.Formatters.JsonFormatter
                                                                                      );
            }
            base.OnActionExecuting(actionContext);
        }




    }
}