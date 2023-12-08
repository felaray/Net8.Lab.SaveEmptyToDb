using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Net8.Lab.SaveEmptyToDb.Data;

namespace Net8.Lab.SaveEmptyToDb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Net8LabSaveEmptyToDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Net8LabSaveEmptyToDbContext") ?? throw new InvalidOperationException("Connection string 'Net8LabSaveEmptyToDbContext' not found.")));

            // Add services to the container.

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
