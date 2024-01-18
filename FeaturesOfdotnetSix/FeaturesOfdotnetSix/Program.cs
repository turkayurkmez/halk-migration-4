var builder = WebApplication.CreateBuilder(args);

//var builder = WebApplication.CreateBuilder(new WebApplicationOptions
//{
//    Args = args,
//    WebRootPath = "spesificwwwroot",
//    ApplicationName = typeof(Program).Assembly.FullName,
//    ContentRootPath = Directory.GetCurrentDirectory(),
//    EnvironmentName = Environments.Production
//});


// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSession();
var valueInSetting = builder.Configuration.GetConnectionString("db");

builder.Logging.AddConsole();

var app = builder.Build();

app.Logger.LogInformation($"Okunan değer: {valueInSetting}");

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

app.UseEndpoints(endpoints => endpoints.MapGet("/test1", () => "Test sayfası"));

app.MapGet("/test2", () => "Aha bu da minimal mapGet()");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
