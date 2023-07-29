using cesapp.Context;
using cesapp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add Sessions
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
    options.IdleTimeout = TimeSpan.FromMinutes(10)
);
// Add database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnections"));
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ISessionsHandler, SessionsHandler>();
// compare it with addSingleton

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseSession();

app.UseStaticFiles();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseRouting();

app.Use(async (context, next) =>
{
    var connectedUser = context.Session.GetString("connectedUser");
    var requestPath = context.Request.Path;


    if (string.IsNullOrEmpty(connectedUser) && requestPath != "/Account/Login")
    {
        context.Response.Redirect("/Account/Login");
        return;
    }

    await next.Invoke();
});
app.Use(async (context, next) =>
{
    var sessionService = context.RequestServices.GetService<ISessionsHandler>();
    var user = sessionService.getUserSession("connectedUser");
    var requestPath = context.Request.Path;
    if (user != null && user.RoleId == 2)
    {
        if (requestPath.StartsWithSegments(new PathString("/User")) || requestPath.StartsWithSegments(new PathString("/Produit")))
        {
            context.Response.Redirect("/Error/AccessDenied");
            return;
        }
    }
    await next.Invoke();
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();