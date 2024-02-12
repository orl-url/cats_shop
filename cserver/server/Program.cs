using Microsoft.AspNetCore.Identity;
using server.Models;
using server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins(
                "http://localhost:5173"
                ).WithMethods("PUT", "DELETE", "GET", "POST");
            policy.AllowCredentials();
            policy.AllowAnyHeader();
        });
});

builder.Services.Configure<CatsStoreDatabaseSettings>(
    builder.Configuration.GetSection("CatsStoreDatabase"));

builder.Services.AddSingleton<CardsService>();
builder.Services.AddSingleton<UsersService>();
builder.Services.AddSingleton<UserPurchasesService>();
builder.Services.AddSingleton<UserBalanceService>();
builder.Services.AddSingleton<UserCartService>();
builder.Services.AddSingleton<ShoppingService>();
builder.Services.AddSingleton<AuthenticationService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication().AddCookie("CookieAuth", options =>
{
    options.Cookie.Name = "CookieAuth";
});

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    // options.Password.RequireDigit = true;
    // options.Password.RequireLowercase = true;
    // options.Password.RequireNonAlphanumeric = true;
    // options.Password.RequireUppercase = true;
    // options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    // options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    // options.User.RequireUniqueEmail = false;
    
    // Default SignIn settings.
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.SlidingExpiration = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();


app.Run();