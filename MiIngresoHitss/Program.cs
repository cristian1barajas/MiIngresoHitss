using Microsoft.EntityFrameworkCore;
using MiIngresoHitss.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MiIngresoHitssDatabase")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "test",
    pattern: "test",
    defaults: new { controller = "Test", action = "Index" });

app.MapControllerRoute(
    name: "producto",
    pattern: "producto",
    defaults: new { controller = "Productos", action = "Index" });

app.MapControllerRoute(
    name: "cliente",
    pattern: "cliente",
    defaults: new { controller = "Clientes", action = "Index" });

app.MapControllerRoute(
    name: "venta",
    pattern: "venta",
    defaults: new { controller = "Ventas", action = "Index" });

app.MapControllerRoute(
    name: "lista",
    pattern: "lista",
    defaults: new { controller = "ListaPrecios", action = "Index" });

app.MapControllerRoute(
    name: "productoLista",
    pattern: "productoLista",
    defaults: new { controller = "ProductoListaPrecios", action = "Index" });

app.MapControllerRoute(
    name: "carrito",
    pattern: "carrito",
    defaults: new { controller = "Carrito", action = "Index" });

app.MapControllerRoute(
    name: "reporteVentas",
    pattern: "{controller=Ventas}/{action=ReporteVentas}/{id?}");

app.Run();
