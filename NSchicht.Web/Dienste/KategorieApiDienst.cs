namespace NSchicht.Web.Dienste
{
    public class KategorieApiDienst
    {
        private readonly HttpClient _httpClient;

        public KategorieApiDienst(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
