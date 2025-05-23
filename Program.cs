using System;
using Jovian_Project_Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Jovian_Project_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var dbProvider = builder.Configuration["DatabaseProvider"];

            if (dbProvider == "MSSQL")
            {
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));
            }
            else if (dbProvider == "MySQL")
            {
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("MySQL"),
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySQL"))));
            }


            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
