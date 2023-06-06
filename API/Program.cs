using Business.Mapping_Profile;
using Business.Services.Implementations;
using Business.Services.Interfaces;
using Data.Data_Access_Layer;
using Data.Repository.Implementations;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        var logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(builder.Configuration)
                        .Enrich.FromLogContext()
                        .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);



        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseMySql(builder.Configuration.GetConnectionString("MyConnectionString"), new MySqlServerVersion(new Version(8, 0, 26)));
        });
        builder.Services.AddScoped<AppDbContext>();
        builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        builder.Services.AddScoped<IDepartmentService, DepartmentService>();
        builder.Services.AddCors();

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