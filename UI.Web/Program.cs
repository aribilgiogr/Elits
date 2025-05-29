using Business.Middlewares;
using Core.Concretes.Maps;
using UI.Web.Models.Maps;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfile<MappingProfile>();
    opt.AddProfile<AccountViewModelProfile>();
});

builder.Services.AddDatabaseConnections(builder.Configuration);
builder.Services.AddDTOServices();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
