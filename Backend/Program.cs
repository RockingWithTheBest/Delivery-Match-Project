using Backend.DatabasContext;
using Backend.Repository.Implementation;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//JSON Serializer
builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
    options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

//Dependancy injection
builder.Services.AddDbContext<ApplicationDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DeliveryMatchString")));

// Register ITrying with its implementation
builder.Services.AddScoped<IAddress,AddressRepository>();
builder.Services.AddScoped<ICustomer, CustomerRepository>();
builder.Services.AddScoped<IDocuments, DocumentRepository>();
builder.Services.AddScoped<IDriver, DriverRepository>();
builder.Services.AddScoped<IEarnings, EarningRepository>();
builder.Services.AddScoped<INotifications, NotificationRepository>();
builder.Services.AddScoped<IOrder_Items, OrderItemRepository>();
builder.Services.AddScoped<IOrder_Placement, OrderPLacementRepository>();
builder.Services.AddScoped<IOrder_Tracking, OrderTrackingRepository>();
builder.Services.AddScoped<IPayment, PaymentRepository>();
builder.Services.AddScoped<IRoute, RouteRepository>();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IVehicle, VehicleRepository>();

var app = builder.Build();

//Enable CORS ~ so that the service can be consumed from the front end of the project
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

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
