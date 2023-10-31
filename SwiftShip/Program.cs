using Microsoft.EntityFrameworkCore;
using SwiftShip.BusinessLogic.Mapper;
using SwiftShip.BusinessLogic.Utils;
using SwiftShip.Database;
using SwiftShip.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBusinessServices();
builder.Services.AddDbServices();
builder.Services.AddAutoMapper(typeof(ParcelMapperProfile));
builder.Services.AddDevExpressBlazor();
builder.WebHost.UseWebRoot("wwwroot");
builder.Services.Configure<DevExpress.Blazor.Configuration.GlobalOptions>(options => {
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
    options.SizeMode = DevExpress.Blazor.SizeMode.Medium;
});
builder.WebHost.UseStaticWebAssets();
builder.Services.AddDbContext<SwiftShipDbContext>
           (options => options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionString")), ServiceLifetime.Transient);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
