using CloudinaryDotNet;
using Luminous.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton(sp => new Cloudinary(new Account("luminous-photos", "573242855749394", "lyE-sIZYM9vw5eXFA5V4pBE7Jko")));

await builder.Build().RunAsync();
