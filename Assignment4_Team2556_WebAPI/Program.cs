using Assignment4_Team2556_WebAPI.Data;
using Assignment4_Team2556_WebAPI.Data.Repositories;
using Assignment4_Team2556_WebAPI.Models;
using Assignment4_Team2556_WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Assignment4_Team2556_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<ICandidateExamService, CandidateExamService>();
            builder.Services.AddScoped<ICandidateExamRepository, CandidateExamRepository>();
            builder.Services.AddScoped<ICandidateExamAnswerService, CandidateExamAnswerService>();
            builder.Services.AddScoped<ICandidateExamAnswerRepository, CandidateExamAnswerRepository>();

            builder.Services.AddScoped<IGenericRepository<Option>, OptionsRepository>();
            builder.Services.AddScoped<IOptionsService, OptionsService>();
            builder.Services.AddScoped<IGenericRepository<Question>, QuestionsRepository>();
            builder.Services.AddScoped<IQuestionsService, QuestionsService>();
            builder.Services.AddScoped<IGenericRepository<Topic>, TopicsRepository>();
            builder.Services.AddScoped<ITopicsService, TopicsService>();

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            //builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}