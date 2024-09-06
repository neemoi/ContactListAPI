using Application.Services.Implementations;
using Application.Services.Interfaces.IServices;
using Application.UnitOfWork;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Repository;

namespace TestTaskContactListAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ContactListContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Registering Services
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IContactService, ContactService>();

            //Registering Repositories
            builder.Services.AddScoped<IContactRepository, ContactRepository>();

            var app = builder.Build();

            //Using migrations for docker
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ContactListContext>();
                dbContext.Database.Migrate();
            }

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