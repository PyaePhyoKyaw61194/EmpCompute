using EmpCompute.Database;
using EmpCompute.Services;
using EmpCompute.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container. 
/* builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>(); */


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>()
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.Configure<IdentityOptions>(options =>
     {
         //Default Password Settings
         options.Password.RequireDigit = true;
         options.Password.RequireLowercase = true;
         options.Password.RequireNonAlphanumeric = false;
         options.Password.RequireUppercase = true;
         options.Password.RequiredLength = 6;
         options.Password.RequiredUniqueChars = 1;
         //Default Lockout settings
         options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
         options.Lockout.MaxFailedAccessAttempts = 5;
         options.Lockout.AllowedForNewUsers = true;
     });

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IPayComputationService, PayComputationService>();
builder.Services.AddScoped<INationalInsuranceContributionService, NationalInsuranceContributionService>();
builder.Services.AddScoped<ITaxService, TaxService>();
builder.Services.AddMvc();
/* RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)builder.Environment);

 */
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

/* app.UseAuthorization(); */
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();

