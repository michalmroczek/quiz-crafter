using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using QuizCrafter.ModularComponents.Infrastructure;
using QuizCrafter.Web;
using QuizCrafter.Web.Shared.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();
builder.Services.AddLocalization(options => options.ResourcesPath = "localization");
builder.Services.AddBlazoredLocalStorage();
/*
builder.Services.AddScoped<LanguageNotifier>();
builder.Services.AddScoped<LocalizationMemoryStorage>();
builder.Services.AddScoped<LazyCultureProvider>();
builder.Services.AddScoped(typeof(IStringLocalizer<>), typeof(web.Services.StringLocalizer<>));
*/
builder.Services.AddScoped<B2CAuthMessageHandler>();
builder.Services.AddHttpClient("QuizCrafter.API", client => client.BaseAddress = new Uri(builder.Configuration["Api:Uri"]))
                .AddHttpMessageHandler<B2CAuthMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("QuizCrafter.API"));

builder.Services.AddInfrastructure();
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.LoginMode = "redirect";
    options.ProviderOptions.DefaultAccessTokenScopes.Add("openid");
    options.ProviderOptions.DefaultAccessTokenScopes.Add("offline_access");
    //options.ProviderOptions.DefaultAccessTokenScopes.Add("https://graph.microsoft.com/User.Read");
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://mmroczek.onmicrosoft.com/48244fe3-6a15-4996-a184-a4128b876903/API.Access");
});

await builder.Build().RunAsync();
