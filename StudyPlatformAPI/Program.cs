
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using Service.Service;
using StudyPlatform;
using StudyPlatform.Models;
using StudyPlatformAPI.MappingProfiles;
using System.Text.Json.Serialization;

namespace StudyPlatformAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StudyPlatformContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IChapterService, ChapterService>();
            builder.Services.AddScoped<IChapterRepository, ChapterRepository>();
            builder.Services.AddScoped<ITopicRepository, TopicRepository>();
            builder.Services.AddScoped<IBoughtSubjectRepository, BoughtSubjectRepository>();
            builder.Services.AddScoped<IProgressRepository, ProgressRepository>();


            builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
            builder.Services.AddScoped<ISubjectService, SubjectService>();
            builder.Services.AddScoped<ITopicService, TopicService>();
            builder.Services.AddScoped<IBoughtSubjectService, BoughtSubjectService>();
            builder.Services.AddScoped<IProgressService, ProgressService>();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicyDevelopement",
            //        policy =>
            //        {
            //            policy
            //                .AllowAnyOrigin()
            //                .AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            //        });
            //});

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BoughtSubjectProfile>();
                cfg.AddProfile<ProgressProfile>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(options => options.WithOrigins("http://localhost:5173")
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
