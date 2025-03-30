using AspNet.Security.OAuth.Discord;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.OpenApi.Models;
using kotkangrilli.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Configuration files
// builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);s
builder.Configuration.AddJsonFile("Properties/appsettings.Development.json", optional: true, reloadOnChange: true);

// Get the configuration
var discordClientId = builder.Configuration["discord:CLIENT_ID"];
var discordClientSecret = builder.Configuration["discord:CLIENT_SECRET"];
var discordRedirectUri = builder.Configuration["discord:CALLBACK_URL"];

// Add Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration?.GetConnectionString("DefaultConnection")));

// Add API Controllers
builder.Services.AddControllers();

// Ensure logging is added
builder.Services.AddLogging(); 

// Add Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "Kotkangrilli API",
        Version = "v2"
    });
    
});

// Add Logging
builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
});

// Add Development CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", policy =>
        policy.AllowAnyOrigin()  // ✅ Allows all origins (Only for Dev)
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add Authentication
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = DiscordAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddDiscord(options =>
    {
        options.ClientId = discordClientId;
        options.ClientSecret = discordClientSecret;
        // options.CallbackPath = new PathString(discordRedirectUri);
        options.CallbackPath = discordRedirectUri;
        options.Scope.Add("identify");
        options.Scope.Add("email");
        options.Scope.Add("guilds.members.read");
        options.SaveTokens = true;
    });

var app = builder.Build();


// Use development Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "Kotkangrilli API v2");
        options.RoutePrefix = string.Empty;
    });
}


// Routing
app.UseRouting();

app.UseCors("DevCors");
app.MapControllers();

app.Run();