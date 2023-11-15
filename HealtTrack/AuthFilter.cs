using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

public class AuthFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Verifique se o usuário está autenticado.
        if (context.HttpContext.User.Identity.IsAuthenticated == false)
        {
            // Redirecione o usuário para a página de login.
            context.Result = new RedirectResult("/Login");
        }
    }
}