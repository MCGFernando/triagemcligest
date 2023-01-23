namespace TriagemCligest.Session
{
    public class SessionValidationMiddleware : IMiddleware
    {
        /*private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionValidationMiddleware(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }*/
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("Midleware");
            /*var session = _httpContextAccessor.HttpContext.Session;
            if (session.GetString("Utilizador") == null)
            {
                context.Response.Redirect("/Login");
                return;
            }*/

            await next(context);
        }
    }
}
