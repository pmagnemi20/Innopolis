using Homework1.Controllers.Model;
using Microsoft.EntityFrameworkCore;
using Homework1.Logging;

namespace Homework1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Logging
                .AddDbLogger(configure => { });
            builder.Services.AddDbContext<CurrencyDbContext>(opt =>
            {
                var config = builder.Configuration;

                var server = config["DbServer"] ?? "ms-sql-server";
                var port = config["DbPort"] ?? "1433";
                var user = config["DbUser"] ?? "sa";
                var password = config["DbPassword"] ?? "P@ssw0rd";

                var connectionString = $"Server={server},{port};Initial Catalog=CurrencyDB;User ID={user};Password={password}";
                opt.UseSqlServer(connectionString);
            });

            builder.PopulateDb();

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

        }
    }
}
