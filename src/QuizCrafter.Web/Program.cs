using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using QuizCrafter.Web;
using QuizCrafter.Web.Services;

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
builder.Services.AddSingleton<ModularComponentProvider>();
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("openid");
    options.ProviderOptions.DefaultAccessTokenScopes.Add("offline_access");
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://graph.microsoft.com/User.Read");
});

await builder.Build().RunAsync();
