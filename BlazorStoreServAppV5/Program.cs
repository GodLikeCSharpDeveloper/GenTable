using BlazorStoreServAppV5.Models.AuthModel;
using BlazorStoreServAppV5.Repository;
using BlazorStoreServAppV5.Repository.AccountLogic;
using BlazorStoreServAppV5.Repository.StoreLogic.CategoryRepository;
using BlazorStoreServAppV5.Repository.StoreLogic.DescriptionRepository;
using BlazorStoreServAppV5.Repository.StoreLogic.FileOploading;
using BlazorStoreServAppV5.Repository.StoreLogic.OrderRepository;
using BlazorStoreServAppV5.Repository.StoreLogic.ProductRepository;
using BlazorStoreServAppV5.Repository.StoreLogic.SearchRepository;
using BlazorStoreServAppV5.Repository.StoreLogic.UserRepository;
using Microsoft.AspNetCore.Authentication;
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
builder.Services.AddScoped<TokenProvider>();
builder.Services.AddScoped<FileUploadService>();
builder.Services.AddTransient<ISearchLucene, SearchLucene>(_ => new SearchLucene("Data"));
builder.Services.AddScoped<IAccountLogic, AccountLogic>();
builder.Services.AddScoped<ICategoryLogic, CategoryLogic>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromDays(20); 
    });
builder.Services.AddAuthentication().AddGoogle(options =>
{
    var clientId = builder.Configuration["Authentication:Google:ClientId"];
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    options.ClaimActions.MapJsonKey("urn:google:profile", "link");
    options.ClaimActions.MapJsonKey("urn:google:image", "picture");
});
builder.Services.AddHttpClient();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddLogging();
builder.Services.AddDbContext<StoreContext>(option =>
    option.EnableSensitiveDataLogging().UseSqlite(builder.Configuration.GetConnectionString("myconn")));
   
    var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCookiePolicy();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
