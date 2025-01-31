
using c240tube.context;
using c240tube.service.abstracts;
using c240tube.service.concrete;
using c240tube.utilty;

namespace c240tube
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();
            #region container
            builder.Services.AddScoped<C240tubeContext>();
            builder.Services.AddScoped<IAuthService,AuthService>();
            builder.Services.AddScoped<IStreamerService,StreamerService>();
            builder.Services.AddScoped<IAdminService,AdminService>();
            builder.Services.AddScoped<ICustomerService,CustomerService>();
            builder.Services.AddScoped<IVideoService,VideoService>();
            builder.Services.AddScoped<ICommentService,CommentService>();
            builder.Services.AddScoped<JwtManager>();
            #endregion


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();
            app.Run();
        }
    }
}
