using System.Text.Json.Serialization;

namespace IMDb_api.Extensions
{
    public static class JsonExtension
    {
        public static IMvcBuilder AddcustomJsonOpt(this IMvcBuilder builder)
        {
            builder.AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            return builder;
        }
    }
}
