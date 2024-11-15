using GraphQL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SignupWebApi.Data;
using SignupWebApi.GraphQl;
using SignupWebApi.GraphQlType;
using SignupWebApi.Modals;
using SignupWebApi.Token;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add GraphQL services
builder.Services.AddGraphQL(options =>
{
    options.AddSystemTextJson();
});
// Configure SQL Server
builder.Services.AddDbContext<UserContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("myCon")));

// Register repositories
builder.Services.AddScoped<IRepo, Repository>();
builder.Services.AddScoped<IService, Service>();

builder.Services.AddScoped<UserQuery>();
builder.Services.AddScoped<UserMutation>();

builder.Services.AddScoped<UserType>();
builder.Services.AddScoped<UserInputType>();

builder.Services.AddScoped<AuthPayloadType>();
builder.Services.AddScoped<AppSchema>();

builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();

//Add token
var secret = "MoinuddinshaikhmainprojectUserDetails";
var key = Encoding.UTF8.GetBytes(secret);
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o => o.TokenValidationParameters = new TokenValidationParameters
{
    RoleClaimType = ClaimTypes.Role,
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateIssuerSigningKey = true,

    ValidIssuer = "authapiMoinuddin",
    ValidAudience = "userapi",
    IssuerSigningKey = new SymmetricSecurityKey(key)
});
builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.UseRouting();

// Configure GraphQL endpoints
app.UseGraphQL<AppSchema>("/api/graphql/User");

app.UseGraphQLGraphiQL("/ui/graphql");

app.UseGraphQLPlayground("/playground");

app.MapControllers();

app.Run();
