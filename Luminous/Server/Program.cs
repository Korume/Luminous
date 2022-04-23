using Luminous.Infrastructure.Models;
using Luminous.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectioString = builder.Configuration["LuminousMongoDb:ConnectionString"];
var databaseName = builder.Configuration["LuminousMongoDb:DatabaseName"];
var productCollectionName = builder.Configuration["LuminousMongoDb:ProductCollectionName"];

builder.Services.Configure<LuminousMongoDbSettings>(l =>
{
    l.ConnectionString = connectioString;
    l.DatabaseName = databaseName;
    l.ProductCollectionName = productCollectionName;
});

builder.Services.AddSingleton<ProductRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
