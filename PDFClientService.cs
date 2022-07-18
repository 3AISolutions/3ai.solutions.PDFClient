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
            string token = "",
            bool landscape = false,
            CancellationToken cancellationToken = default)
        {
            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Add("Authorization", token);

            if (landscape)
                _httpClient.DefaultRequestHeaders.Add("landscape", "true");

            var response = await _httpClient.GetAsync($"PDFURL?dataUrl={url}", cancellationToken);
            return await response.Content.ReadAsByteArrayAsync(cancellationToken);
        }
    }
}