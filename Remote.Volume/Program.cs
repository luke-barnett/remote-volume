using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Remote.Volume
{
	public class Program
	{
		public static void Main(string[] args)
		{
			bool isService = true;
			if (Debugger.IsAttached || args.Contains("--console"))
			{
				isService = false;
			}

			var pathToContentRoot = isService ?
					Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) :
					Directory.GetCurrentDirectory();

			var configuration = new ConfigurationBuilder()
									.AddCommandLine(args)
									.Build();

			var host = WebHost.CreateDefaultBuilder(args)
				.UseContentRoot(pathToContentRoot)
				.UseConfiguration(configuration)
				.UseStartup<Startup>()
				.Build();

			if (isService)
			{
				host.RunAsService();
			}
			else
			{
				host.Run();
			}
		}
	}
}