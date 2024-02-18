using DNTCaptcha.Core;
using FA.JustBlog.DataAccess.Data;
using FA.JustBlog.DataAccess.Repository.IRepository;
using FA.JustBlog.Repository;
using FA.JustBlog.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using FA.JustBlog.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
           .AddEntityFrameworkStores<ApplicationDbContext>()
           .AddDefaultTokenProviders();




builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddDNTCaptcha(options =>
{
    // options.UseSessionStorageProvider() // -> It doesn't rely on the server or client's times. Also it's the safest one.
    // options.UseMemoryCacheStorageProvider() // -> It relies on the server's times. It's safer than the CookieStorageProvider.
    options
        .UseCookieStorageProvider() // -> It relies on the server and client's times. It's ideal for scalability, because it doesn't save anything in the server's memory.
        .AbsoluteExpiration(7)
        .RateLimiterPermitLimit(10) // for .NET 7x, Also you need to call app.UseRateLimiter() after calling app.UseRouting().
        .ShowThousandsSeparators(false)
        .WithNoise(0.015f, 0.015f, 1, 0.0f)
        .WithEncryptionKey("This is my secure key!")
        .WithNonceKey("NETESCAPADES_NONCE")
        .InputNames( // This is optional. Change it if you don't like the default names.
                    new DNTCaptchaComponent
                    {
                        CaptchaHiddenInputName = "DNT_CaptchaText",
                        CaptchaHiddenTokenName = "DNT_CaptchaToken",
                        CaptchaInputName = "DNT_CaptchaInputText",
                    })
        .Identifier("dnt_Captcha") // This is optional. Change it if you don't like its default name.
        ;
});
builder.Services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).
    AddDataAnnotationsLocalization();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("vie"),
    };
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedUICultures = supportedCultures;
});

var app = builder.Build();

//var supportedCultures = new[] { "en", "vie" };
//var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
//    .AddSupportedCultures(supportedCultures)
//    .AddSupportedUICultures(supportedCultures);

//app.UseRequestLocalization(localizationOptions);
app.UseRequestLocalization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
// Default route
app.MapAreaControllerRoute(
          name: "Admin",
          areaName: "Admin",
          pattern: "Admin/{controller=Post}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Post}/{action=Index}");
app.MapControllerRoute(
    name: "Register",
    pattern: "Identity/Account/Register");
app.MapControllerRoute(
    name: "PostDetails",
    pattern: "Post/{year}/{month}/{title}",
    defaults: new { controller = "Post", action = "Details" },
    constraints: new { year = @"\d{4}", month = @"\d{2}" }
);

app.MapControllerRoute(
    name: "Category",
    pattern: "Category/{name}",
    defaults: new { controller = "Category", action = "Details" }
);

app.MapControllerRoute(
    name: "Tag",
    pattern: "Tag/{name}",
    defaults: new { controller = "Tag", action = "Details" }
);



app.MapRazorPages();

app.Run();
