using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyLibraryApp.Data;
using MyLibraryApp.Model;
using MyLibraryApp.MyServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

builder.Services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultCon")));

// Security context service
builder.Services.AddScoped<ISecurityContext, SecurityContext>();

// Cookie authentication
builder.Services.AddAuthentication("CookieAuthentication")
    .AddCookie("CookieAuthentication", options =>
    {
        options.Cookie.Name = "CookieAuthentication";
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

// Authorization policy
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("LoggedInUsersOnly", policy => policy
        .RequireClaim("Role"));

    options.AddPolicy("AdminOnly", policy => policy
        .RequireClaim("Role", "2"));
});

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
