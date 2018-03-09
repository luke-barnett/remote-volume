using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Remote.Volume
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			services.AddTransient<IAudioController, CoreAudioController>();

			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v0", new Info { Title = "Remote Volume", Version = "v0" });
			});
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();

			app.UseSwaggerUI(options =>
			{
				options.RoutePrefix = string.Empty;
				options.SwaggerEndpoint("/swagger/v0/swagger.json", "Remote Volume v0");
			});

			app.UseMvc();
		}
	}
}