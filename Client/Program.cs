using HiroshimaInfo.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new Localization(((IJSInProcessRuntime)sp.GetRequiredService<IJSRuntime>()).Invoke<bool>("eval", "/^ja\\b/.test(navigator.language)") ? "ja" : "en"));

// Console.WriteLine(((IJSInProcessRuntime)builder.Services.First(x => x.ServiceType == typeof(IJSRuntime)).ImplementationInstance!).Invoke<bool>("eval", "/^ja\\b/.test(navigator.language)"));
// foreach (var service in builder.Services) Console.WriteLine(service.ServiceType.FullName);

await builder.Build().RunAsync();
