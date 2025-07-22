using App.Application.Services;
using Blazored.LocalStorage;
using CareBridge.Client.Auth;
using CurrieTechnologies.Razor.SweetAlert2;
using MatBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register the authenticated HTTP client handler
builder.Services.AddScoped<AuthenticatedHttpClientHandler>();

// Configure HttpClient with the authenticated handler
builder.Services.AddScoped(sp =>
{
    var handler = sp.GetRequiredService<AuthenticatedHttpClientHandler>();
    handler.InnerHandler = new HttpClientHandler();

    var httpClient = new HttpClient(handler)
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    };

    return httpClient;
});

builder.Services.AddMatBlazor();

// Add CurrieTechnologies.Blazor.SweetAlert2 Service
builder.Services.AddSweetAlert2(options =>
{
    options.Theme = SweetAlertTheme.Dark;
});

// Blazored LocalStorage
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<CascadingAuthenticationState>();

// Authentication
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();

// Register LoaderService for client-side


builder.Services.AddMatToaster(config =>
{
    config.Position = MatToastPosition.TopRight;
    config.PreventDuplicates = true;
    config.NewestOnTop = true;
    config.ShowCloseButton = true;
    config.MaximumOpacity = 95;
    config.VisibleStateDuration = 3000;
});



await builder.Build().RunAsync();
