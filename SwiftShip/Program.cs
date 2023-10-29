using Microsoft.EntityFrameworkCore;
using SwiftShip.BusinessLogic;
using SwiftShip.BusinessLogic.Mapper;
using SwiftShip.Database;
using SwiftShip.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IParcelBusinessLogic, ParcelBusinessLogic>();
builder.Services.AddScoped<IParcelStageHistoryBusinessLogic, ParcelStageHistoryBusinessLogic>();
builder.Services.AddSingleton<IStageBusinessLogic, StageBusinessLogic>();
builder.Services.AddAutoMapper(typeof(ParcelMapperProfile));
builder.Services.AddDbServices();
builder.Services.AddDevExpressBlazor();
//builder.WebHost.UseWebRoot("wwwroot");
//builder.WebHost.UseStaticWebAssets();
builder.Services.AddDbContext<SwiftShipDbContext>
           (options => options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
