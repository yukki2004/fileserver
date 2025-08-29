using WebApplication4.src.Application.Subject.Command;
using WebApplication4.src.Application.Subject.Queries;
using WebApplication4.src.Infrastructure.Data;
using WebApplication4.src.Infrastructure.Resposity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication4.src.Domain.Entities;
using WebApplication4.src.Application.Subject.DTOs;
using WebApplication4.src.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using WebApplication4.src.Infrastructure.FileStorageService.Subject;
using Microsoft.Extensions.FileProviders;
using WebApplication4.src.Infrastructure.FileStorageService.Document;

namespace WebApplication4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDataConText>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<ISubjectResposity, SubjectResposity>();
            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(AddSubjectCommandHandle).Assembly));
            builder.Services.AddScoped<IDocumentResposity, DocumentResposity>();
            builder.Services.AddScoped<IFileService, AddSubjectStorageService>();
            builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(AddDocumentCommandHandle).Assembly));
            builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(DeleteDocumentCommandHanlde).Assembly));
            builder.Services.AddScoped<IDocumentFileService, DocumentStorageService>();



            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var fileServerPath = builder.Configuration["FileStorage:RootPath"];
            var app = builder.Build();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(fileServerPath),
                RequestPath = "/files"
            });

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
