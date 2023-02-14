using EmpCompute.Database;
using EmpCompute.Services;
using EmpCompute.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container. 
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IPayComputationService, PayComputationService>();
builder.Services.AddScoped<INationalInsuranceContributionService, NationalInsuranceContributionService>();
builder.Services.AddScoped<ITaxService, TaxService>();
RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)builder.Environment);


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

