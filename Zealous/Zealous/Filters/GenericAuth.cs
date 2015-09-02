using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Zealous.Auth;

namespace Zealous.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class GenericAuth : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            var identity = FetchAuthHeader(actionContext);

            if (identity == null)
            {
                ChallengeAuthRequest(actionContext);
                return;
            }

            var genericPrincipal = new GenericPrincipal(identity, null);
            Thread.CurrentPrincipal = genericPrincipal;

            if (!OnAuthorizeUser(identity.Name, identity.Password, actionContext))
            {
                ChallengeAuthRequest(actionContext);
                return;
            }
        }

        protected  bool OnAuthorizeUser(string user, string pass, HttpActionContext actionContext)
        {
            if (new Domain.Users().Authenticate(user, pass))
            {
                return true;
            }
            return false;
        }

        protected Identity FetchAuthHeader(HttpActionContext actionContext)
        {
            string authHeaderValue = null;
            var authRequest = actionContext.Request.Headers.Authorization;
            if (authRequest != null && !String.IsNullOrEmpty(authRequest.Scheme) && authRequest.Scheme == "Basic")
                authHeaderValue = authRequest.Parameter;
            if (string.IsNullOrEmpty(authHeaderValue))
                return null;
            authHeaderValue = Encoding.Default.GetString(Convert.FromBase64String(authHeaderValue));
            var credentials = authHeaderValue.Split(':');
            return credentials.Length < 2 ? null : new Identity(credentials[0], credentials[1]);
        }

        /// <summary>
        /// Send the Authentication Challenge request
        /// </summary>
        /// <param name="filterContext"></param>
        private static void ChallengeAuthRequest(HttpActionContext actionContext)
        {
            var dnsHost = actionContext.Request.RequestUri.DnsSafeHost;
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", dnsHost));
        }

    }
}