using CityApiCom;
using CityApiCom.Data;
using CityApiCom.Interfaces;
using CityApiCom.Mappings;
using CityApiCom.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddTransient<Seed>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

//if (args.Length == 1 && args[0].ToLower() == "seeddata") SeedData(app);

/*void SeedData(IHost app)
{
    var ScopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = ScopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}*/

// Configure the HTTP request pipeline.
var a = app.Environment.IsDevelopment();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/*using (var context = new DataContext())
{
    var posts = context.Cities
        .Where(p => p.Id == 1)
    var posts = context.Cities
        .Where(t => t = &gt; t.PostTags.Any(pt = &gt; pt.Tag == "sqlbulkcopy"))
        .Select(p = &gt; p);

    foreach (var post in posts)
    {
        foreach (var linkPost in post.LinkedPosts)
        {
            // Do something important.
        }
    }
}*/