using System;
using System.Text;
using KyuApi.Business.Services.Auth;
using KyuApi.Business.Services.Main;
using KyuApi.Data;
using KyuApi.Data.Options;
using KyuApi.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace KyuApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<JwtOptions>(Configuration.GetSection("JwtOptions"));
			services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
			services.AddDbContext<KyuContext>(o => o.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
			services.AddRepositoryWrapper();
			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<IKyuService, KyuService>();
			var secret = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtOptions").Get<JwtOptions>().Secret);
			services.AddAuthentication(b =>
			{
				b.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				b.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(b =>
			{
				b.RequireHttpsMetadata = false;
				b.SaveToken = true;
				b.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(secret),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serv)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseCors();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			serv.CreateEntryTypes();
			serv.CreateEntryStatuses();
		}
	}
}
