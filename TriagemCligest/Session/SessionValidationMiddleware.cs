using Microsoft.AspNetCore.Http;
using System;
using static System.Collections.Specialized.BitVector32;

namespace TriagemCligest.Session
{
    public class SessionValidationMiddleware : IMiddleware
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionValidationMiddleware(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            var pathElements = context.Request.Path.ToString();
            Console.WriteLine("pathElements " + pathElements);

            /*if (pathElements== "/")
            {
                var session = _httpContextAccessor.HttpContext.Session;
                if (session.GetString("Utilizador") == null)
                {
                    Console.WriteLine("Middleware not authenticated");
                    context.Response.StatusCode = 403;
                    context.Response.Redirect("/Login/Index");
                    return;
                }
                
            }*/

            if (pathElements != "/" && pathElements != "/Login/Index" && pathElements != "/Login/Login")
            {
                var session = _httpContextAccessor.HttpContext.Session;
                if (session.GetString("Utilizador") == null)
                {
                    Console.WriteLine("Middleware not authenticated");
                    context.Response.StatusCode = 403;
                    context.Response.Redirect("/Login/Index");
                    return;
                }
            }

                /*var session = _httpContextAccessor.HttpContext.Session;

                if (session.GetInt32("AuthExecuted") == null)
                {
                    session.SetInt32("AuthExecuted", 1);
                    await next(context);
                    return;
                }

                if (session.GetString("Utilizador") == null)
                {
                    Console.WriteLine("Middleware not authenticated");
                    context.Response.StatusCode = 403;
                    await next(context);
                    return;
                }

                context.Response.StatusCode = 200;
                context.Response.Redirect("/Home/Index");*/
                /*Console.WriteLine("Midleware" + context.Response.StatusCode);
                var session = _httpContextAccessor.HttpContext.Session;
                if (context.Response.StatusCode == 403)
                {
                    if (session.GetString("Utilizador") == null)
                    {
                        Console.WriteLine("Midleware Nao Autenticado1 ");
                        context.Response.StatusCode = 403;
                        context.Response.Redirect("Login/Inde");
                        return;
                    }
                }

                if (context.Response.StatusCode == 200)
                {
                    if (session.GetString("Utilizador") == null)
                    {
                        Console.WriteLine("Midleware Nao Autenticado2 ");
                        context.Response.StatusCode = 403;
                        context.Response.Redirect("Login/Inde");
                        return;
                    }
                    else { context.Response.StatusCode = 200; }
                }*/

                await next(context);
        }
    }
}
