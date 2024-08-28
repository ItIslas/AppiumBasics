using Microsoft.Extensions.Configuration;

namespace AppiumExercises.Config
{
    static class AppSettings
    {
        private static IConfiguration config
        {
            get
            {
                var builder = new ConfigurationBuilder();
                builder.SetBasePath(Configure.PROJ_DIRECTORY)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                return builder.Build();
            }
        }
        public static string get(string name)
        {
            string? var = config[name];
            if (var != null)
            {
                return var;
            }
            throw new ArgumentNullException(name);
        }
        public static string get(string name, string defVal)
        {
            string? var = config[name];
            if (var != null)
            {
                return var;
            }
            return defVal;
        }
    }
}
