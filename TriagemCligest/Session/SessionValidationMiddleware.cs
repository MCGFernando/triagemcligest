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
            Console.WriteLine("Midleware");
            /*ar session = _httpContextAccessor.HttpContext.Session;
            if (session.GetString("Utilizador") == null)
            {
                Console.WriteLine("Midleware Nao Autenticado");
                context.Response.Redirect("/Login");
                return;
            }*/
            await next(context);
        }
    }
}
