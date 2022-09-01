using System.Text;
using Data;
using Dominio.DTOs.FilmesDtos;
using Dominio.Entities;
using FluentValidation.AspNetCore;
using IMDb_api.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Service.Profiles;

var builder = WebApplication.CreateBuilder(args);

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntityType<Filme>();
    builder.EntitySet<FilmeDto>("FilmeDto");
    builder.EntityType<FilmeDto>().HasKey(x => x.Id);
    return builder.GetEdmModel();
}

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(UserProfile), typeof(FilmeProfile), typeof(AvaliacaoProfile), typeof(ElencoProfile));

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("v1", GetEdmModel()).Filter().Select().Expand());

builder.Services.AddServices();


var JWt_KEY = builder.Configuration.GetValue<string>("Criptograph:SecretKey");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWt_KEY)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCustomSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
