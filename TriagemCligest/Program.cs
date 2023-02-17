using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TriagemCligest.Data;
using TriagemCligest.Service;
using TriagemCligest.Session;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TriagemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TriagemContext") ?? throw new InvalidOperationException("Connection string 'TriagemContext' not found.")));
builder.Services.AddDbContext<CligestUContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CligestUContext") ?? throw new InvalidOperationException("Connection string 'CligestUContext' not found.")));
builder.Services.AddDbContext<CligestSIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CligestSIContext") ?? throw new InvalidOperationException("Connection string 'CligestSIContext' not found.")));
builder.Services.AddDbContext<CligestMainContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CligestMainContext") ?? throw new InvalidOperationException("Connection string 'CligestMainContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<EspecialidadeService>();
builder.Services.AddScoped<FuncionarioService>();
builder.Services.AddScoped<MarcacaoService>();
builder.Services.AddScoped<OperadorService>();
builder.Services.AddScoped<UtenteService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<TriagemService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddTransient<SessionValidationMiddleware>();

/*builder.Services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", config =>
{
    config.Cookie.Name = "Credenciais";
    config.LoginPath = "/Login/Index";
});*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.UseMiddleware<SessionValidationMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");



app.Run();
