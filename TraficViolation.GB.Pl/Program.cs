using TraficViolation.GB.Infrastructure.Extension;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TraficViolation.GB.Domain.Entities.Identity;
using TraficViolation.GB.Infrastructure.Data.Context;
using TraficViolation.GB.Infrastructure.Data.Seed;
using TraficViolation.GB.Domain.Shared.EmailConfig;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TraficViolation.GB.Pl
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Real-Time Traffic Violation Logger API", Version = "v1" });


                // Define the security scheme
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                // Apply the security requirement globally
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    });
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
                };
            });

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.AllowedUserNameCharacters =
                     "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._ ";
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 4;
            })
           .AddEntityFrameworkStores<TraficViolationDbContext>()
           .AddDefaultTokenProviders();

            builder.Services.AddDependancies(builder.Configuration);

           

            builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration"));


            var app = builder.Build();

            //return group of isercieseScope work with liftime scope 
            // Ê»„« «‰ «· stroe dbcontext ‘€«·Â scope › Â —Ã⁄Â«  
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            // return object from storeDbContext .
            var context = services.GetRequiredService<TraficViolationDbContext>();
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            try
            {
                // Update DataBase && Apply Migrations
                await context.Database.MigrateAsync();
                await TraficViolationDbContextSeed.SeedRoles(roleManager);
                await TraficViolationDbContextSeed.SeedAppUser(userManager);

            }
            catch (Exception ex)
            {
                var loggerfactory = services.GetRequiredService<ILoggerFactory>();
                var logger = loggerfactory.CreateLogger<Program>();
                logger.LogError(ex, "there are problems during apply migrations");
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); 
            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
