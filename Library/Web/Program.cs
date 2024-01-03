using Infrastructure.Ioc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(40);
});

var sharedFolder = Path.Combine(builder.Environment.ContentRootPath, "..", "ConfigFiles");

builder.Configuration.AddJsonFile(Path.Combine(sharedFolder, "sharedsettings.json"), optional: true)
        .AddJsonFile("sharedsettings.json", optional: true);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();

DependencyInjection.RegisterServices(builder.Services, builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
