using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;

namespace TransportMe.API.Tests.IntegrationTests
{
    public class TransportMeTestFixture<TStartup> : IDisposable
    {
        public HttpClient Client { get; }

        private readonly TestServer _server;

        public TransportMeTestFixture()
            : this(Path.Combine("src"))
        {
        }

        protected TransportMeTestFixture(string relativeTargetProjectParentDir)
        {
            var startupAssembly = typeof(TStartup).GetTypeInfo().Assembly;
            var contentRoot = GetProjectPath(relativeTargetProjectParentDir, startupAssembly);

            var builder = new WebHostBuilder()
                .UseContentRoot(contentRoot)
                .ConfigureServices(InitializeServices)
                .UseEnvironment("Development")
                .UseStartup(typeof(TStartup));

            _server = new TestServer(builder);

            Client = _server.CreateClient();
            Client.BaseAddress = new Uri("https://localhost:5000");
        }


        protected virtual void InitializeServices(IServiceCollection services)
        {
            // var startupAssembly = typeof(TStartup).GetTypeInfo().Assembly;

            // Inject a custom application part manager. 
            // Overrides AddMvcCore() because it uses TryAdd().
            //var manager = new ApplicationPartManager();
            //manager.ApplicationParts.Add(new AssemblyPart(startupAssembly));
            //manager.FeatureProviders.Add(new ControllerFeatureProvider());
            //manager.FeatureProviders.Add(new ViewComponentFeatureProvider());

            //services.AddSingleton(manager);
        }

        /// <summary>
        /// Gets the full path to the target project that we wish to test
        /// </summary>
        /// <param name="projectRelativePath">
        /// The parent directory of the target project.
        /// e.g. src, samples, test, or test/Websites
        /// </param>
        /// <param name="startupAssembly">The target project's assembly.</param>
        /// <returns>The full path to the target project.</returns>
        private static string GetProjectPath(string projectRelativePath, Assembly startupAssembly)
        {
            // Get name of the target project which we want to test
            var projectName = startupAssembly.GetName().Name;

            // Get currently executing test project path
            var applicationBasePath = System.AppContext.BaseDirectory;

            // Find the path to the target project
            var directoryInfo = new DirectoryInfo(applicationBasePath);
            do
            {
                directoryInfo = directoryInfo.Parent;

                var projectDirectoryInfo = new DirectoryInfo(Path.Combine(directoryInfo.FullName, projectRelativePath));
                if (projectDirectoryInfo.Exists)
                {
                    var projectFileInfo = new FileInfo(Path.Combine(projectDirectoryInfo.FullName, projectName, $"{projectName}.csproj"));
                    if (projectFileInfo.Exists)
                    {
                        return Path.Combine(projectDirectoryInfo.FullName, projectName);
                    }
                }
            }
            while (directoryInfo.Parent != null);

            throw new Exception($"Project root could not be located using the application root {applicationBasePath}.");
        }

        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}