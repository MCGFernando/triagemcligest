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
            Console.WriteLine("Midleware" + context.Response.StatusCode);
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

            /*if (context.Response.StatusCode == 200)
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
