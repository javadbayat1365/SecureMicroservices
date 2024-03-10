using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);



builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddAuthentication()
	.AddJwtBearer("IdentityApiKey", x => {
		x.Authority = "https://localhost:5005"; // Identity Server Url
		x.TokenValidationParameters = new TokenValidationParameters {
			ValidateAudience = false
		};
	});


builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello Ocelot"); 

await app.UseOcelot();
app.Run();
