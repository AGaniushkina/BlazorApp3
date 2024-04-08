using BlazorApp2.Server.Services;
using BlazorApp2.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AirportDatabaseSettings>(
    builder.Configuration.GetSection("AirportDatabase"));

builder.Services.AddSingleton<RoutesService>();
builder.Services.AddSingleton<FlightsService>();
builder.Services.AddSingleton<PassengersService>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
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

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();