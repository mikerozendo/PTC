using Microsoft.Extensions.FileProviders;
using PTC.Application.Services;
using PTC.Domain.Interfaces.Repository;
using PTC.Domain.Interfaces.Services;
using PTC.Infrastructure.Data.Respository;
using PTC.Web.Models.Interfaces.Services;
using PTC.WEB;
using PTC.WEB.Models.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.RegisterDependency();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "CORS",
//                      policy =>
//                      {
//                          policy.AllowAnyHeader()
//                          .AllowAnyHeader()
//                          .AllowAnyMethod()
//                          .AllowAnyOrigin();
//                      });
//});

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
//app.UseCors("CORS");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Operacao}/{action=Index}/{id?}");

app.Run();
