/*
Made by: Ignas Budzinskas
*/
using Microsoft.EntityFrameworkCore;
using App.Models;
using App.Services;
using App.Helpers;

const string policy = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policy, builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
}
);*/
builder.Services.AddControllers();
builder.Services.AddDbContext<BookContext>(opt => opt.UseInMemoryDatabase("Books"));
builder.Services.AddScoped<IBookLook, BookLook>();
builder.Services.AddScoped<IBookReserve, BookReserve>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using(var scope = app.Services.CreateScope()){
    var context = scope.ServiceProvider.GetRequiredService<BookContext>();
    var seeder = new DataSeeder(context);
    seeder.SeededData();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app. UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options => options
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors(policy);

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
