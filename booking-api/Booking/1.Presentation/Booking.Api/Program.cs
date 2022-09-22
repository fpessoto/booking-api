using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Booking.Api.Config;
using Booking.Domain.Interfaces;
using Booking.Domain.Users;
using Booking.Infrastructure.DatabaseEFCore.Context;
using Booking.Infrastructure.DatabaseEFCore.Users;
using System.Text;
using Booking.Application.Interfaces;
using Booking.Application.Services;
using Booking.Domain.Reservations;
using Booking.Infrastructure.DatabaseEFCore.Reservations;
using Booking.Infrastructure.DatabaseEFCore.Rooms;
using Booking.Domain.Rooms;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

static void RegisterServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    Booking.Infrastructure.DatabaseEFCore.Dependencies.ConfigureServices(builder.Configuration, builder.Services);


    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
    builder.Services.AddScoped<IRoomRepository, RoomRepository>();

    builder.Services.AddScoped<IReservationService, ReservationService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IRoomService, RoomService>();
}