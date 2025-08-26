using WebApplication4.src.Application.Subject.Command;
using WebApplication4.src.Application.Subject.Queries;
using WebApplication4.src.Infrastructure.Data;
using WebApplication4.src.Infrastructure.Reposity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication4.src.Domain.Entities;
using WebApplication4.src.Application.Subject.DTOs;

namespace WebApplication4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDataConText>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
