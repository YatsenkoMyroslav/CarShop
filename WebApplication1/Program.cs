using WebApplication1.Data;
using WebApplication1.Data.Interaces;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Repository;
using WebApplication1.Data.Models;
using WebApplication1.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContent>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IAllCars, CarRepository>();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();
builder.Services.AddTransient<IAllOrders, OrderRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCart.GetCart(sp));

builder.Services.AddMvc();

builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseHttpsRedirection();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "categoryFilter",
        pattern: "{controller=Cars}/{action=List}/{category?}");
});

using (var scope = app.Services.CreateScope())
{
    AppDbContent content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
    DBObjects.Initial(content);
}


app.Run();
