using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< Updated upstream
// Đăng ký DbContext
=======
// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
// DbContext
>>>>>>> Stashed changes
builder.Services.AddDbContext<MilkContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký UnitOfWork
builder.Services.AddScoped<UnitOfWork>();
<<<<<<< Updated upstream
=======
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

>>>>>>> Stashed changes

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


