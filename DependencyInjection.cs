using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace _3ai.solutions.PDFClient;

public static class DependencyInjection
{
    public static IServiceCollection AddPDFClient(this IServiceCollection services, string baseAddress, string licence)
    {
        services.AddHttpClient<PDFClientService>(
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
