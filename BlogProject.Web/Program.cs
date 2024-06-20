using BlogProject.DAL.Concrete;
using BlogProject.BLL.Services.Concrete;
using BlogProject.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using BlogProject.DAL.Concrete.Context;
using BlogProject.BLL.Describers;
using BlogProject.Web.Filters.ArticleVisitors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();     

builder.Services.AddControllersWithViews(o => 
{
    o.Filters.Add<ArticleVisitorFilter>();  
});

builder.Services.AddScopedDAL();    
builder.Services.AddScopedBLL();

builder.Services.AddIdentity<AppUser, AppRole>
    (
        
    )
    .AddRoleManager<RoleManager<AppRole>>()
    .AddErrorDescriber<CustomIdentityErrorDescriber>()
    .AddEntityFrameworkStores<AppIdentityContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config => 
{                                  
    config.LoginPath = new PathString("/Admin/Authorize/Login");  
    config.LogoutPath = new PathString("/Admin/Authorize/Logout");
    config.Cookie = new CookieBuilder 
    { 
        Name = "BlogProject",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest   
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromMinutes(8);
    config.AccessDeniedPath = new PathString("/Admin/Authorize/AccessDenied");   
});

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

app.UseSession();           

app.UseRouting();

app.UseAuthentication();    
app.UseAuthorization();     

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute
    (
        name: "Admin",
        areaName: "Admin", pattern: "Admin/{Controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute
    (
        name: "default", pattern: "{controller=Home}/{action=About}/{id?}"
    );

    endpoints.MapDefaultControllerRoute();
});

app.Run();
