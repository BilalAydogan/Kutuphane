using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Web.Code.Filters
{
    public class AuthActionFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public string Rol;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!string.IsNullOrEmpty(Rol))
            {
                bool isAuthorized = Rol.Split(',').Contains(Repo.Session.Rol);
                if (!isAuthorized)
                    context.Result = new UnauthorizedResult();
            }
            else if (string.IsNullOrEmpty(Repo.Session.Email))
            {
                context.Result = new UnauthorizedResult();
            }
        }
        /*
         * Action çalışmadan önce
         */
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
        /*
         * Action çalıştıktan sonra
         */
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
        /*
         * Tam response'u kullanıcıya göndermeden önce çalıştırılır
         */
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
        }
        /*
         * Sonucu gönderdik ve bu metod çalışıyor
         */
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
        }
    }
}
