using Microsoft.EntityFrameworkCore;
using PaginationSampleNet8.Domain.Helper.Cache;
using PaginationSampleNet8.Domain.Clients.Pokemons;
using PaginationSampleNet8.Domain.Data;
using PaginationSampleNet8.Domain.Services.Pokemons;
using PaginationSampleNet8.Repository.Users;
using PaginationSampleNet8.Services.Cars;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WebApiDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("WebApiDatabase"))
);

builder.Services.AddMemoryCache();

builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CacheHelper>();
builder.Services.AddScoped<PokemonClient>();
builder.Services.AddScoped<PokemonService>();



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

app.UseSwagger();
app.UseSwaggerUI();

//if (app.Environment.IsDevelopment())
//{
//app.UseSwagger();
//app.UseSwaggerUI();
//}

app.Run();
