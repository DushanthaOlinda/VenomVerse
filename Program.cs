using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VenomVerseApi;
using VenomVerseApi.Models;

var builder = WebApplication.CreateBuilder(args);
var myAllowedOrigins ="_myAllowedOrigins";

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<VenomVerseContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db"))
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(
        JwtBearerDefaults.AuthenticationScheme, 
        options => builder.Configuration.Bind("JwtSettings", options)
    );
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowedOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:5173",
                                "https://localhost:5173",
                                "http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

builder.Services
    .AddIdentityCore<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.User.RequireUniqueEmail = true;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    }).
    AddEntityFrameworkStores<VenomVerseContext>();

builder.Services.AddScoped<TokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors(myAllowedOrigins);


// Migrate latest database changes during startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<VenomVerseContext>();
    
    // Here is the migration executed
    dbContext.Database.Migrate();
}

app.Run();
