using BlazorStoreServAppV5.Repository;
using BlazorStoreServAppV5.Repository.AccountLogic;
using BlazorStoreServAppV5.Repository.StoreLogic.NewFolder;
using BlazorStoreServAppV5.Repository.StoreLogic.NewFolder1;
using BlazorStoreServAppV5.Repository.StoreLogic.NewFolder2;
using BlazorStoreServAppV5.Repository.StoreLogic.NewFolder3;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IOrderRepositoryServise, OrderRepository>();
builder.Services.AddScoped<IDescriptionRepositoryService, DescriptionRepository>();
builder.Services.AddScoped<IUserRepositoryService, UserRepository>();
builder.Services.AddScoped<IProductRepositoryService, ProductRepository>();
builder.Services.AddScoped<IAccountLogic, AccountLogic>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromDays(20);
    });
builder.Services.AddDbContext<StoreContext>(option =>
    option.UseSqlite(builder.Configuration.GetConnectionString("myconn")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
