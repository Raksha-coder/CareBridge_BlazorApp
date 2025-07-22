using System.Text;
using App.Infrastructure;
using Blazored.LocalStorage;
using CareBridge.Auth;
using CareBridge.Client.Auth;
using CurrieTechnologies.Razor.SweetAlert2;
using MatBlazor;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using MudBlazor.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

// Serilog configuration
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

// Added MatBlazor Service 
builder.Services.AddMatBlazor();
// Added MatBlazor Toaster Service
builder.Services.AddMatToaster(config =>
{
    config.Position = MatToastPosition.TopRight;
    config.PreventDuplicates = true;
    config.NewestOnTop = true;
    config.ShowCloseButton = true;
    config.MaximumOpacity = 95;
    config.VisibleStateDuration = 3000;
});

// Add CurrieTechnologies.Blazor.SweetAlert2 Service
builder.Services.AddSweetAlert2(options =>
{
    options.Theme = SweetAlertTheme.Dark;
});

// Add JWT handler
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key is missing in configuration")))
        };
    });
builder.Services.AddHttpClient();

// Add Authorization
builder.Services.AddAuthentication();
// Added Cascading Parameter
builder.Services.AddScoped<CascadingAuthenticationState>();
// Blazored LocalStorage
builder.Services.AddBlazoredLocalStorage();
// Add Authentication State Provider for server-side
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
// Authentication

// Loader Service

// Core Services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddInfra(configuration);

builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddControllers();

// Added Swagger/OpenAPI support
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();
app.MapControllers();
app.MapRazorComponents<CareBridge.Components.App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(CareBridge.Client._Imports).Assembly);

await app.RunAsync();
