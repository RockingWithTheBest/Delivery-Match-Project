using Backend.DatabasContext;
using Backend.Microservice.JWT;
using Backend.Repository.Implementation;
using Backend.Repository.Interface;
using Backend.Services.Routing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Text;



internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Add CORS policy
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowReactApp",
                policy =>
                {
                    policy.WithOrigins("http://localhost:4606")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
        });

        //Dependancy injection
        builder.Services.AddDbContext<ApplicationDatabaseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DeliveryMatchString")));


        // Register implementation
        builder.Services.AddScoped<IAddress, AddressRepository>();
        builder.Services.AddScoped<ICustomer, CustomerRepository>();
        builder.Services.AddScoped<IDocuments, DocumentRepository>();
        builder.Services.AddScoped<IDriver, DriverRepository>();
        builder.Services.AddScoped<IEarnings, EarningRepository>();
        builder.Services.AddScoped<INotifications, NotificationRepository>();
        builder.Services.AddScoped<IOrderItems, OrderItemRepository>();
        builder.Services.AddScoped<IOrderPlacement, OrderPLacementRepository>();
        builder.Services.AddScoped<IOrderTracking, OrderTrackingRepository>();
        builder.Services.AddScoped<IPayment, PaymentRepository>();
        builder.Services.AddScoped<IRoute, RouteRepository>();
        builder.Services.AddScoped<IUser, UserRepository>();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<IVehicle, VehicleRepository>();
        builder.Services.AddScoped<IPasswordHasher<Backend.Models.User>, PasswordHasher<Backend.Models.User>>();
        builder.Services.AddScoped<TokenProvider>();
        builder.Services.AddScoped<LoginUser>();
        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer
            (
                o =>
                    {
                        o.RequireHttpsMetadata = false;
                        o.TokenValidationParameters = new TokenValidationParameters
                        {
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!)),
                            ValidIssuer = builder.Configuration["Jwt:Issuer"],
                            ValidAudience = builder.Configuration["Jwt:Audience"],
                            ClockSkew = TimeSpan.Zero
                        };
                    }
            );

        // Register Route Optimization Services
        builder.Services.AddScoped<IGeocodingService, MockGeocodingService>();
        builder.Services.AddScoped<RouteOptimizationService>();// Core optimization service
        //builder.Services.AddScoped<AcoRoutingEngine>();// ACO algorithm engine
       
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //JSON Serializer
        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
            options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

        var app = builder.Build();

        //Enable CORS ~ so that the service can be consumed from the front end of the project
        //app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowReactApp");
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}