using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Produit.Presentation.Client;
using Produit.Presentation.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<FakeAccountDatabase>();

builder.Services.AddFluxor(options => {
    options.ScanAssemblies(typeof(Program).Assembly);
    options.UseReduxDevTools();
});

await builder.Build().RunAsync();
