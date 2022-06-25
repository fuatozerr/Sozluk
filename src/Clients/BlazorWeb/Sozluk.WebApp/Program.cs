using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sozluk.WebApp;
using Sozluk.WebApp.Infrastructure.Service;
using Sozluk.WebApp.Infrastructure.Service.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("WebApiClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5068");
});//auth eklenecek

builder.Services.AddScoped(sp => {
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
    return clientFactory.CreateClient("WebApiClient");
});

builder.Services.AddTransient<IVoteService, VoteService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
