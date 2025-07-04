
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

            builder.Services.AddScoped<IChapterRepository, ChapterRepository>();
            builder.Services.AddScoped<ITopicRepository, TopicRepository>();
            builder.Services.AddScoped<IBoughtSubjectRepository, BoughtSubjectRepository>();
            builder.Services.AddScoped<IProgressRepository, ProgressRepository>();
            builder.Services.AddScoped<ITopicProgressRepository, TopicProgressRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
            builder.Services.AddScoped<IFollowingRepository, FollowingRepository>();
            builder.Services.AddScoped<IAchievementRepository, AchievementRepository>();
            builder.Services.AddScoped<IAccomplishAchievementRepository, AccomplishAchievementRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IChapterProgressRepository, ChapterProgressRepository>();

            builder.Services.AddScoped<IChapterService, ChapterService>();
            builder.Services.AddScoped<ITopicService, TopicService>();
            builder.Services.AddScoped<ISubjectService, SubjectService>();
            builder.Services.AddScoped<IBoughtSubjectService, BoughtSubjectService>();
            builder.Services.AddScoped<IProgressService, ProgressService>();
            builder.Services.AddScoped<ITopicProgressService, TopicProgressService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IFollowingService, FollowingService>();
            builder.Services.AddScoped<IAchievementService, AchievementService>();
            builder.Services.AddScoped<IAccomplishAchievementService, AccomplishAchievementService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IChapterProgressService, ChapterProgressService>();

            builder.Services.AddEndpointsApiExplorer();


            builder.Services.AddRouting(options => options.LowercaseUrls = true);
             

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BoughtSubjectProfile>();
                cfg.AddProfile<ProgressProfile>();
                cfg.AddProfile<TopicProgressProfile>();
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<FollowingProfile>();
                cfg.AddProfile<AchievementProfile>();
                cfg.AddProfile<AccomplishAchievementProfile>();
                cfg.AddProfile<CommentProfile>();
                cfg.AddProfile<ChapterProfile>();
                cfg.AddProfile<TopicProfile>();
                cfg.AddProfile<QuestionProfile>();
                cfg.AddProfile<ChapterProgressProfile>();
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
