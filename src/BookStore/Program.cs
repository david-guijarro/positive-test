using BookStore.Services;
using Kontent.Ai.Delivery.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IKontentAIClient, KontentAIClient>();
builder.Services.AddDeliveryClient(configuration);


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();
// app.MapAreaControllerRoute("details",)
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(name: "pagination",
            pattern: "/page/{page}",
            defaults: new { controller = "Home", action = "Index" });


app.MapControllerRoute(name: "details",
            pattern: "details/{codename}",
            defaults: new { controller = "Details", action = "Index" });

app.Run();
