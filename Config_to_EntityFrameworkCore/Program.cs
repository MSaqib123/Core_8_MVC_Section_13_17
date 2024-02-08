var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endP =>
{
    endP.Map("/", async context =>
    {
        //___________ 1. Way 1 Getting Value from appsettng.JSON______
        string s1 = app.Configuration["MyKey"];
        await context.Response.WriteAsync(s1);

        //___________ 2. Way 2 Getting Value from appsettng.JSON______
        string s2 = app.Configuration.GetValue<string>("MyKey");
        await context.Response.WriteAsync(s2);

    });
});
app.MapControllers();
app.Run();
