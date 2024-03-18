using System.Configuration;

namespace QuizCrafter.Modules.Quizzes.Api.Startup
{
    public static class HostExtensions
    {
        private const string CorsConfigKey = "Cors";

        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            var corsSettings = configuration
                .GetSection(CorsConfigKey)
                .Get<CorsSettings>();

            if (corsSettings is null)
            {
                throw new ConfigurationErrorsException(
                    $"'{CorsConfigKey}' configuration section is required");
            }

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .WithOrigins(corsSettings.AllowedOrigins)
                        .WithHeaders(corsSettings.AllowedHeaders)
                        .WithMethods(corsSettings.AllowedMethods);
                });
            });
        }

        private sealed record CorsSettings(string[] AllowedOrigins, string[] AllowedHeaders, string[] AllowedMethods);
    }
}
