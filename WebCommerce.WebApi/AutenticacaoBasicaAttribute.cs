using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace WebCommerce.WebApi
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AutenticacaoBasicaAttribute : TypeFilterAttribute
    {
        public AutenticacaoBasicaAttribute() : base(typeof(AutenticacaoBasicaHandler))
        {
        }
    }

    public class AutenticacaoBasicaHandler : IAuthorizationFilter
    {


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                string cabecalho = context.HttpContext.Request.Headers["Authorization"];

                if (cabecalho != null)
                {
                    var authHeaderValue = AuthenticationHeaderValue.Parse(cabecalho);
                    if (authHeaderValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(), StringComparison.OrdinalIgnoreCase)) {
                        var credenciais = Encoding.UTF8
                                            .GetString(Convert.FromBase64String(authHeaderValue.Parameter ?? string.Empty))
                                            .Split(':', 3);

                        if (credenciais.Length == 3)
                            if (EstaAutenticado(context, credenciais[0], credenciais[1], credenciais[2]))
                                return;

                    }
                }

                NaoAutorizadoResult(context);
            }
            catch (FormatException)
            {
                NaoAutorizadoResult(context);
            }
        }

        public bool EstaAutenticado(AuthorizationFilterContext context, string username, string password, string data)
        {
            //BUSCAR INFORMAÇÕES EM MEMÓRIA CACHE
            var listaDeUsuarios = new System.Collections.Generic.Dictionary<string, string> {
                { "uniaraxa", "uni@r@x@" },
                { "bembrasil", "b3mbr4s1l" },
                { "eletrozema", "3l3tr0z3m4" },
                { "cbmm", "semsenha" }
            };

            return listaDeUsuarios.Any(f => f.Key == username && f.Value == password) && Convert.ToDateTime(data).AddMinutes(5) < DateTime.Now;
        }

        private void NaoAutorizadoResult(AuthorizationFilterContext context)
        {
            // Return 401 and a basic authentication challenge (causes browser to show login dialog)
            context.Result = new UnauthorizedResult();
        }
    }

    ///// <summary>
    ///// OnAuthorization
    ///// </summary>
    ///// <param name="context"></param>
    //public void OnAuthorization(AuthorizationFilterContext context)
    //{
    //    try
    //    {
    //        string authHeader = context.HttpContext.Request.Headers["Authorization"];
    //        if (authHeader != null)
    //        {
    //            var authHeaderValue = AuthenticationHeaderValue.Parse(authHeader);
    //            if (authHeaderValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(), StringComparison.OrdinalIgnoreCase))
    //            {
    //                var credentials = Encoding.UTF8
    //                                    .GetString(Convert.FromBase64String(authHeaderValue.Parameter ?? string.Empty))
    //                                    .Split(':', 3);
    //                if (credentials.Length == 3) {
    //                    if (EstaAutorizado(context, credentials[0], credentials[1], Convert.ToDateTime(credentials[2]))) {
    //                        return;
    //                    }
    //                }
    //            }
    //        }

    //        AcessoNaoAutorizado(context);
    //    }
    //    catch (FormatException)
    //    {
    //        AcessoNaoAutorizado(context);
    //    }

    //}

    //private bool EstaAutorizado(AuthorizationFilterContext context, string username, string password, DateTime data)
    //{
    //    if (data.AddSeconds(5) < DateTime.Now)
    //        return false;

    //    if (!(username == "renato" && password == "teste*123"))
    //        return false;

    //    return true;
    //}

    //private void AcessoNaoAutorizado(AuthorizationFilterContext context)
    //{
    //    // Return 401 and a basic authentication challenge (causes browser to show login dialog)
    //    //context.HttpContext.Response.Headers["WWW-Authenticate"] = $"Basic realm=\"{_realm}\"";
    //    context.Result = new UnauthorizedResult();
    //}


}
