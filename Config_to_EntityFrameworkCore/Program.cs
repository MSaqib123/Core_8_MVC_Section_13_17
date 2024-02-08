var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endP =>
{
    endP.Map("/", async context =>
    {
        //___________ 1. Getting Value from appsettng.JSON______
        string s = app.Configuration["MyKey"];
        await context.Response.WriteAsync(s);
    });
});
app.MapControllers();
app.Run();
