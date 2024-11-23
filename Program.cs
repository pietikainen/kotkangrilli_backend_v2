using AspNet.Security.OAuth.Discord;
using Microsoft.OpenApi.Models;
using kotkangrilli.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Configuration files
// builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile("Properties/appsettings.Development.json", optional: true, reloadOnChange: true);

// Get the configuration
var discordClientId = builder.Configuration?["Discord:ClientId"];
var discordClientSecret = builder.Configuration?["Discord:ClientSecret"];
var discordRedirectUri = builder.Configuration?["Discord:RedirectUri"];

// Print for giggles
Console.WriteLine("Discord Client ID: " + discordClientId);
Console.WriteLine("Discord Client Secret: " + discordClientSecret);
Console.WriteLine("Discord Redirect URI: " + discordRedirectUri);

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

app.MapControllers();

app.Run();