using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace TestingGoogle
{
    public class TestingAppSettings
    {
        public static IConfiguration GetTestSettings()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var basePath = Path.GetDirectoryName(path);

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("testSettings.json",
                    optional: false,
                    reloadOnChange: true);

            var config = builder.Build() as IConfiguration;
            return config;
        }
    }
}
