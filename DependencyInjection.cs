using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace _3ai.solutions.PDFClient
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPDFHttp(this IServiceCollection services, string baseAddress, string licence)
        {
            services.AddHttpClient<PDFHttpClientService>(
                    o =>
                    {
                        o.BaseAddress = new(baseAddress);
                        o.DefaultRequestHeaders.Add("licence", licence);
                    })
                    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                    {
                        AutomaticDecompression = DecompressionMethods.All,
                    });
            return services;
        }
    }
}