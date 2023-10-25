using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TrungTamLuaDao.Repository;
using TrungTamLuaDao.IRepository;
using System.Text.Json.Serialization;
using TrungTamLuaDao.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddScoped<IAccountRepo, AccountRepo>();
        builder.Services.AddScoped<IAnswerRepo, AnswerRepo>();
        builder.Services.AddScoped<IAssignmentRepo, AssignmentRepo>();
        builder.Services.AddScoped<ICourseRepo, CourseRepo>();
        builder.Services.AddScoped<IEnrollmentRepo, EnrollmentRepo>();
        builder.Services.AddScoped<IExamTypeRepo, ExamTypeRepo>();
        builder.Services.AddScoped<IFeedbackRepo, FeedbackRepo>();
        builder.Services.AddScoped<ILectureRepo, LectureRepo>();
        builder.Services.AddScoped<IMaterialRepo, MaterialRepo>();
        builder.Services.AddScoped<IMaterialTypeRepo, MaterialTypeRepo>();
        builder.Services.AddScoped<IMultipleChoiceQuestionRepo, MultipleChoiceQuestionRepo>();
        builder.Services.AddScoped<IStudentRepo, StudentRepo>();
        builder.Services.AddScoped<ISubmissionRepo, SubmissionRepo>();
        builder.Services.AddScoped<ITutorAssignmentRepo, TutorAssignmentRepo>();
        builder.Services.AddScoped<ITutorRepo, TutorRepo>();
        builder.Services.AddScoped<ILectureTypeRepo, LectureTypeRepo>();
        builder.Services.AddScoped<IStatusTypeRepo, StatusTypeRepo>();
        builder.Services.AddScoped<IFeeRepo, FeeRepo>();
        builder.Services.AddScoped<IPaymentHistoryRepo, PaymentHistoryRepo>();
        builder.Services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(option =>
        {
            option.SaveToken = true;
            option.RequireHttpsMetadata = false;
            option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value))
            };
        });
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.WriteIndented = true;
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}