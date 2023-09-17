
using DB_Test_Fox.Models;
using DB_Test_Fox.Repository.AccomodationRepository;
using DB_Test_Fox.Repository.PriceListRepository;
using DB_Test_Fox.Repository.RoomTypeRepository;

namespace Api_Test_Fox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped(_ =>
                    new BookingContext(builder.Configuration.GetConnectionString("DB_Fox_Connection")));

            builder.Services.AddScoped<IAccomodationRepository, AccomodationRepository>();
            builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            builder.Services.AddScoped<IPriceListRepository, PriceListRepository>();


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