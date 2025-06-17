using MovieManagement.MappingProfiles;
using MovieManagement.Data; // Add this for MovieContext
using Microsoft.EntityFrameworkCore; // Add this for UseSqlite
using MovieManagement.Services;
using MovieManagement.Repositories;
using MovieManagement.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();

builder.Services.AddScoped<IMovieService, MovieService>();

ConfigureFluentValidation(builder.Services);
void ConfigureFluentValidation(IServiceCollection services)
{
    services.AddTransient<IValidator<MovieManagement.Models.Movie>, MovieValidator>();
    services.AddTransient<IValidator<MovieManagement.Models.Genre>, GenreValidator>();
}
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
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Initialize the database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MovieContext>();
    dbContext.Database.Migrate(); // Apply migrations
}
app.Run();
