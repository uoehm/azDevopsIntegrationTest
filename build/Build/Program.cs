using Build.Common.Extensions;

using Cake.Frosting;

using Microsoft.Extensions.DependencyInjection;

namespace Build
{
    public class Program : IFrostingStartup
    {
        /// <summary>Configures services used by Cake.</summary>
        /// <param name="services">The services to configure.</param>
        public void Configure(IServiceCollection services)
        {
            // Register the tools
            services.UseTool("nuget:?package=NuGet.CommandLine".AsUri());
            services.UseTool("nuget:?package=GitVersion.CommandLine".AsUri());
            services.UseTool("nuget:?package=NUnit.ConsoleRunner".AsUri());
        }

        public static int Main(string[] args) =>
            // Create the host.
            new CakeHost()
                .UseStartup<Program>()
                .UseContext<Context>()
                .UseLifetime<Lifetime>()
                .UseWorkingDirectory("../..")
                .Run(args);
    }
}
