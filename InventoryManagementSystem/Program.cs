using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InventoryManagementSystem.Context;
using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Implementation.Interface;
using InventoryManagementSystem.Implementation.Repository;
using InventoryManagementSystem.Implementation.Services;
using InventoryManagementSystem.Implementation.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity services
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Register repositories
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//Register Services
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProductService, ProductService>();

// Add controllers with views
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=SignUp}/{id?}");

app.Run();
