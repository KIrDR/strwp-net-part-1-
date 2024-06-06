using ASPCMVC06.Controllers;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=TMResearch}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "GETMO1_1",
        pattern: "/MResearch/M01/1",
        defaults: new { controller = "TMResearch", action = "GETM01" });

    endpoints.MapControllerRoute(
        name: "GETMO1_2",
        pattern: "/MResearch/M01",
        defaults: new { controller = "TMResearch", action = "GETM01" });

    endpoints.MapControllerRoute(
        name: "GETMO1_3",
        pattern: "/MResearch",
        defaults: new { controller = "TMResearch", action = "GETM01" });

    endpoints.MapControllerRoute(
        name: "GETMO1_4",
        pattern: "/",
        defaults: new { controller = "TMResearch", action = "GETM01" });

    endpoints.MapControllerRoute(
        name: "GETMO1_5",
        pattern: "V2/MResearch/M01",
        defaults: new { controller = "TMResearch", action = "GETM01" });

    endpoints.MapControllerRoute(
        name: "GETMO1_6",
        pattern: "V3/MResearch/{str}/M01",
        defaults: new { controller = "TMResearch", action = "GETM01" });

    ///////////////////////////////////////////////////////////////////////

    endpoints.MapControllerRoute(
        name: "GETMO2_1",
        pattern: "/V2",
        defaults: new { controller = "TMResearch", action = "GETM02" });

    endpoints.MapControllerRoute(
        name: "GETMO2_2",
        pattern: "V2/MResearch",
        defaults: new { controller = "TMResearch", action = "GETM02" });

    endpoints.MapControllerRoute(
        name: "GETMO2_3",
        pattern: "V2/MResearch/M02",
        defaults: new { controller = "TMResearch", action = "GETM02" });

    endpoints.MapControllerRoute(
        name: "GETMO2_4",
        pattern: "/MResearch/M02",
        defaults: new { controller = "TMResearch", action = "GETM02" });

    endpoints.MapControllerRoute(
        name: "GETMO2_5",
        pattern: "V3/MResearch/{str}/M02",
        defaults: new { controller = "TMResearch", action = "GETM02" });

    ///////////////////////////////////////////////////////////////////////

    endpoints.MapControllerRoute(
        name: "GETMO3_1",
        pattern: "/V3",
        defaults: new { controller = "TMResearch", action = "GETM03" });

    endpoints.MapControllerRoute(
        name: "GETMO3_2",
        pattern: "V3/MResearch/{str}/",
        defaults: new { controller = "TMResearch", action = "GETM03" });

    endpoints.MapControllerRoute(
        name: "GETMO3_3",
        pattern: "V3/MResearch/{str}/M03",
        defaults: new { controller = "TMResearch", action = "GETM03" });

    ///////////////////////////////////////////////////////////////////////

    endpoints.MapControllerRoute(
        name: "GETMXX",
        pattern: "{**uri}",
        defaults: new { controller = "TMResearch", action = "GETMXX" });

    endpoints.MapControllers();
});

app.Run();
