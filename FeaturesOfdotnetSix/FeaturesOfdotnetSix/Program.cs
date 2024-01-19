using Autofac;
using Autofac.Extensions.DependencyInjection;
using FeaturesOfdotnetSix.Services;

var builder = WebApplication.CreateBuilder(args);

//IHostBuilder ve IWebHostBuilder interface'leri aşağıdaki iki satırda olduğu gibi özelleştirilebilir:
builder.Host.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromMinutes(5));


//IoC (Inversion of Control Container) provider'i örnek olarak Autofac için aşağıdaki gibi özelleştirebilirsiniz.

//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//builder.Host.ConfigureContainer<ContainerBuilder>(builder=>builder.RegisterModule())

builder.WebHost.UseHttpSys();

//Minimal hosting değişim yönetimi:

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
builder.Services.AddSession(option => option.IdleTimeout = TimeSpan.FromMinutes(5));
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Ya Autofac ile IoC kullanmak istersem?


//builder.Services.AddSi
var valueInSetting = builder.Configuration.GetConnectionString("db");
//Log format değiştirme (ekleme):
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

if (app.Environment.IsDevelopment())
{
    //3.1'de sık kullandığımız DatabaseErrorPage() yerini aşağıdaki extension metoda bıraktı.
    //Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore nuget paketinde bulunabilir...
    app.UseDeveloperExceptionPage();
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

