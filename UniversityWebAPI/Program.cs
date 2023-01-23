using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UniversityWebAPI;
using UniversityWebAPI.DataAccess;
using UniversityWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

//connection with SqlServerExpress
const string ConnectionName = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(ConnectionName);

//add context to service builder

builder.Services.AddDbContext<UniversitysDBContext>(options =>
    options = options.UseSqlServer(connectionString));

//add services of jwt autorization
builder.Services.AddJwtTokenServices(builder.Configuration);


builder.Services.AddControllers();

//add Custom services
builder.Services.AddScoped<IStudentsServices, StudentsServices>();


//Add autorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(name: "UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});


//todo: Add the rest of services

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Config swaguer to take care of autorization of JWT
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWt authorization header using bearer scheme"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[]{}
        }
    });
});


//TODO: Config Swagger to take care of autorization of JWT
builder.Services.AddSwaggerGen();



//Cors configuration
builder.Services.AddCors(options => 
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
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

app.UseAuthorization();

app.MapControllers();

//tell app use cors
app.UseCors("CorsPolicy");
app.Run();
