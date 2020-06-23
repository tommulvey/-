using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WikiSpeedia.Abstractions;

namespace WikiSpeedia.Objects
{
    public class ConfigurationService : IConfigurationService
    {
        public IEnviornmentService EnvService { get; }
        public string CurrentDirectory { get; set; }

        public ConfigurationService(IEnviornmentService envService)
        {
            EnvService = envService;
        }

        public IConfiguration GetConfiguration()
        {
            CurrentDirectory = CurrentDirectory ?? Directory.GetCurrentDirectory();
            return new ConfigurationBuilder()
                .SetBasePath(CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{EnvService.EnviornmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
