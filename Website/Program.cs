using Microsoft.EntityFrameworkCore;
using Website.Data.Tutorial;
using Website.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();


//builder.Services.AddSingleton<TestService>();
//builder.Services.AddScoped<TestService>();
builder.Services.AddTransient<TestService>();



IConfiguration configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
.Build();


var connectionString = configuration.GetValue<string>("Connections:Tutorial");

builder.Services.AddDbContext<TutorialContext>(options =>
{
    options.UseSqlServer(connectionString,
    sqlOptions =>
    {
        sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    }
    );
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
