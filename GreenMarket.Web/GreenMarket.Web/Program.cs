using GreenMarket.Domain.Entities;
using GreenMarket.Infrastructure.Persistence;
using GreenMarket.Web.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;

// AppSetting
services.Configure<AppSetting>(configuration);
var appSettings = new AppSetting();
configuration.Bind(appSettings);

// Add Infrastructure (Connect database)
services.AddInfrastructure(appSettings.ConnectionStrings.DefaultConnection);

// Add IdentityUser
services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Add CORS policy
services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
       $"v1",
       new OpenApiInfo()
       {
           Title = "GreenMarket API",
           Version = "1",
           Description = "GreenMarket API Specification.",
           Contact = new OpenApiContact
           {
               Email = "ngxdung172@gmail.com",
               Name = "Nguyen Xuan Dung",
               Url = new Uri("https://github.com/milod172"),
           },
           License = new OpenApiLicense
           {
               Name = "MIT License",
               Url = new Uri("https://opensource.org/licenses/MIT"),
           },
       });
   
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

// Redirect root "/" to "/swagger"
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }
    await next();
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
