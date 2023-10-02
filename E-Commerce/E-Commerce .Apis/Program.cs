using E_Commerce.BL.IService;
using E_Commerce.BL.Services;
using E_Commerce.DAL.context;
using E_Commerce.DAL.IRepository;
using E_Commerce.DAL.models;
using E_Commerce.DAL.Repository;
using E_Commerce_.Apis.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace E_Commerce_.Apis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers().AddNewtonsoftJson();
                
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Database and connectionString

            builder.Services.AddDbContext<ECommerceDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultconnection"));
            });
            #endregion

            #region add services
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
            builder.Services.AddScoped<IBrandRepo, BrandRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IOrderRepo,OrderRepo>();





            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService , CategoryService>();
            builder.Services.AddScoped<IBrandService , BrandService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IOrderService,OrderService>();


            #endregion

            #region redis
            //builder.Services.AddSingleton<IConnectionMultiplexer>(c =>
            //{
            //    var options = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"));
            //    return ConnectionMultiplexer.Connect(options);
            //});
            #endregion

            #region add identity

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;

                options.User.RequireUniqueEmail = true;
            })
               .AddEntityFrameworkStores<ECommerceDBContext>()
               .AddDefaultTokenProviders()
               .AddUserStore<UserStore<ApplicationUser, IdentityRole, ECommerceDBContext, string>>()
               .AddRoleStore<RoleStore<IdentityRole, ECommerceDBContext, string>>();
            #endregion

            #region autoMapper
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion

            #region cors
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            #endregion

            #region Authentication Scheme

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Cool";
                options.DefaultChallengeScheme = "Cool";
            })
            .AddJwtBearer("Cool", options =>
            {
                var secretKeyString = builder.Configuration.GetValue<string>("SecretKey");
                var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
                var secretKey = new SymmetricSecurityKey(secretyKeyInBytes);

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = secretKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            #endregion

            #region Authorization

            builder.Services.AddAuthorization(options =>
            {
            options.AddPolicy("Admin", policy => policy
                .RequireClaim(ClaimTypes.Role, "Admin"));
                


            });
            #endregion


            var app = builder.Build();

            app.UseGlobalExceptionHandling(); 

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}