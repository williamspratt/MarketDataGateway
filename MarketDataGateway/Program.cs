using DataValidationService.Model;
using DataValidationService.Model.Dto;
using DataValidationService.Services;
using System;

namespace MarketDataGateway // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static IRepositoryService<IMarketDataFx> globalRepositoryService = new RepositoryService();

        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            InjectDummyData(); // # # FOR TEST PURPOSES # # 

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

        // for test purposes only
        private static void InjectDummyData()
        {

            globalRepositoryService.CreateMarketData(new MarketDataFx(true, "GBPUSD", 1.24M, 100000), out string err0);
            globalRepositoryService.CreateMarketData(new MarketDataFx(true, "GBPEUR", 1.14M, 90000), out string err1);
            //globalRepositoryService.CreateMarketData(new MarketDataFx(true, "GBPIRR", 52280.95M, 1000), out string err2);

        }
    }
}

