using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// JWT configuration
// string securityKey = "mysuperdupersecret";    this was short for the algorithm, now using a more secure key
string securityKey = "mysuperduperultrasecretkeyforJWT123456";

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "mySystem",
        ValidAudience = "myUsers",
        IssuerSigningKey = key
    };
});

builder.Services.AddAuthorization();
builder.Services.AddControllers(); 

var app = builder.Build();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
