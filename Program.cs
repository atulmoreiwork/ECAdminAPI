using ECAdminAPI.Repositories;
using ECAdminAPI.Services;
using NLog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ECAdminAPI.Models;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);


ConfigurationManager configuration = builder.Configuration;
var jwtTokenConfig = configuration.GetSection("JwtTokenConfig").Get<TokenConfig>();
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton(jwtTokenConfig);
builder.Services.AddSingleton<ILoggerManager,LoggerManager>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<ITokenRepository,TokenRepository>();
builder.Services.AddScoped<IGridDataHelperRepository,GridDataHelperRepository>();
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
builder.Services.AddScoped<IOrderShippingAddressRepository,OrderShippingAddressRepository>();
builder.Services.AddScoped<IDocumentRepository,DocumentRepository>();
builder.Services.AddScoped<IRoleRepository,RoleRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(op => {
    op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtTokenConfig.Issuer,
        ValidAudience = jwtTokenConfig.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret))
    };
});

// Configure Kestrel server limits
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 104857600; // 100 MB
});
var app = builder.Build();
app.Use(async (context, next) =>
{
    var maxRequestBodySizeFeature = context.Features.Get<IHttpMaxRequestBodySizeFeature>();
    if (maxRequestBodySizeFeature != null)
    {
        maxRequestBodySizeFeature.MaxRequestBodySize = 104857600; // 100 MB
    }
    await next.Invoke();
});
app.UseCors(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
