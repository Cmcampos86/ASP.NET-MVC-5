using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace DevIO.AppMvc.Extensions
{
    public class CustomAuthorization
    {
        public static bool ValidarClaimsUsuario(string claimName, string claimValue)
        {
            //As claims e as roles ficam nos cookies
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;//Pega as claims do usuário logado
            var claim = identity.Claims.FirstOrDefault(c => c.Type == claimName);//Possui a claim com o nome passado
            return claim != null && claim.Value.Contains(claimValue);//Se achou a claim retorna true
        }
    }

    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _claimName;
        private readonly string _claimValue;

        public ClaimsAuthorizeAttribute(string claimName, string claimValue)
        {
            _claimName = claimName;
            _claimValue = claimValue;
        }

        //Manipular requests não autorizado
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new HttpStatusCodeResult((int)HttpStatusCode.Forbidden);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return CustomAuthorization.ValidarClaimsUsuario(_claimName, _claimValue);
        }
    }
}