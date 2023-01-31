using Microsoft.EntityFrameworkCore;
using PS.Domain;
using PS.Infrustructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<CPU>();
builder.Services.AddTransient<SchedulerFactory>();
builder.Services.AddTransient<ProcessService>();
builder.Services.AddDbContext<SimulatorContext>(option => option
    .UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("Simulator")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
