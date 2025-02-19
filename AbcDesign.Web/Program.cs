using AbcDesign.Business;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// DbContext. The default DI lifetime of AddDbContext is Scoped.
builder.Services.AddDbContext<AbcDesign.DataLayer.MainDbContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MainDB"));
});


// DI Business logic. Controllers call the business layer for data
builder.Services.AddScoped<ICatalogManager, CatalogManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
