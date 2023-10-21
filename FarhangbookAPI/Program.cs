using FarhangbookAPI.PublicClasses;
using FarhangbookAPI.Services.Interface;
using FarhangbookAPI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebMarkupMin.AspNetCore7;
using Microsoft.AspNetCore.Identity;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region سرویس های مربوط به ورود به سیستم
builder.Services.AddScoped<ILoginService, LoginService>();
//
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
	options.AccessDeniedPath = "/Account/AccessDenied";
	options.LoginPath = "/Account/Login";
	options.LogoutPath = "/Account/Login";

	options.ExpireTimeSpan = TimeSpan.FromHours(6);
	options.Cookie.IsEssential = true;
	options.SlidingExpiration = true;
});
#endregion

#region سرویس مربوط به تاریخ شمسی
builder.Services.AddTransient<ConvertDate>();
#endregion

#region سرویس مربوط به بهینه سازی صفحات در پروژه
//WebMarkupMin.AspNetCore7  : استفاده از پکیج کاربری مخصوص ورژن 7 دات نت کور
//NuGet\Install-Package WebMarkupMin.AspNetCore7 -Version 2.14.1
builder.Services.AddWebMarkupMin(option =>
{
	option.AllowCompressionInDevelopmentEnvironment = true;
	option.AllowMinificationInDevelopmentEnvironment = true;
}).AddHtmlMinification(
            options =>
            {
                options.MinificationSettings.RemoveRedundantAttributes = true;
                options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
                options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
            })
  .AddHttpCompression();

#endregion

#region PWA سرویس مربوط به
builder.Services.AddProgressiveWebApp();


#endregion

#region متد های مربوط به نوتیفیکیشن
builder.Services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
{
	ProgressBar = true,
	PositionClass = ToastPositions.TopCenter
});
#endregion


// Services Registered Identity

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseWebMarkupMin();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseNToastNotify();

//1
app.UseAuthentication();

//2
app.UseAuthorization();

app.MapControllerRoute(
	name: "AdminArea",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Account}/{action=Login}/{id?}");


app.MapControllerRoute(
	name: "UserArea",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
