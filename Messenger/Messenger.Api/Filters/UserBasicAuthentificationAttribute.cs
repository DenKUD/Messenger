using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Http.Filters;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

namespace Messenger.Api.Filters
{
    public class UserBasicAuthentificationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                Guid user_id;
                try
                {
                    user_id = Guid.Parse(decodedToken.Substring(0, decodedToken.IndexOf(":")));
                }
                catch (Exception e)
                {
                    throw new ArgumentNullException(e.Message);
                    
                }
                string password = decodedToken.Substring(decodedToken.IndexOf(":") + 1);
                if (!Messenger.Api.Extentions.Authenticator.Authentificate(user_id, password))
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);

            }

        }
    }
}