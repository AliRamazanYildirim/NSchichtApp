namespace NSchicht.Web.Dienste
{
    public class ProduktApiDienst
    {
        private readonly HttpClient _httpClient;

        public ProduktApiDienst(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
