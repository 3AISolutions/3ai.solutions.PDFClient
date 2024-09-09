namespace _3ai.solutions.PDFClient
{
    public class PDFClientService
    {
        private readonly HttpClient _httpClient;

        public PDFClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<byte[]> GetPDFAsync(
            string url,
            string? token = null,
            bool landscape = false,
            CancellationToken cancellationToken = default)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, $"PDFURL?dataUrl={url}");
            if (token is not null)
                message.Headers.Add("Authorization", token);
            if (landscape)
                message.Headers.Add("landscape", "true");
            var response = await _httpClient.SendAsync(message, cancellationToken);
            return await response.Content.ReadAsByteArrayAsync(cancellationToken);
        }
    }
}