using DragTrans.Application.Interfaces;
using DragTrans.Application.Services.Register;
using DragTrans.Infrastructure.Data;
using DragTrans.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using DragTrans.Application.Services.LogIn;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DragTransDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<RegisterService>();
builder.Services.AddScoped<LogInService>(); ;

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();