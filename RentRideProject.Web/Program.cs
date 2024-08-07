
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using VehicleRentRideProject.Repositories.Implementation;
using VehicleRentRideProject.Repositories.Infrastructure;
using VehicleRentRideProject.Repositories;
using Microsoft.EntityFrameworkCore;
using RentRideProject.Web.CustomerMiddleWare;
using Microsoft.AspNetCore.Identity;
using RentRideProject.Web.Mapper;
using RentRideProject.Models;
//using RentRideProject.Web.Data;

var builder = WebApplication.CreateBuilder(args);
//configure dbcontext with connectionstring
builder.Services.AddDbContext<CarContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<CarContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
//builder .Services.AddAutoMapper(typeof (VehicleRepository));
//var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseMiddleware<ExceptionHandlerMiddleWare>();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vehicles}/{action=Index}/{id?}");

app.Run();*/

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new VehicleProfile(builder.Environment));
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "VehicleProjectCookie"; //set unique name to session
    options.IdleTimeout = TimeSpan.FromMinutes(1);//set session timeout duration
    options.Cookie.HttpOnly = true; //Ensures the session cookie is only accessiable

});
