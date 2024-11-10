using managementorder.Helper;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IConfiguration>(config);
// Register HttpClient as a named service for "ProductApi"
builder.Services.AddHttpClient("ProductApi", client =>
{
    client.BaseAddress = new Uri(config.GetValue<string>("ApiParam:url")); // replace with actual API base URL
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
// Register AutoMapper with profile
builder.Services.AddAutoMapper(typeof(AutoMapperProfile)); // Register your profile
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
