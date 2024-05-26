
using PronounceAPI.Models;
using PronounceAPI.Services;

namespace PronounceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Add services to the container.
            builder.Services.Configure<PronounceAPIDatabaseSettings>(
                builder.Configuration.GetSection("PronounceAPIDatabase"));

            builder.Services.AddSingleton<WordsService>();

            builder.Services.AddControllers()
                 .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

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
