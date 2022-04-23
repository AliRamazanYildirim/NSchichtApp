using NSchicht.Kern.DÜOe;

namespace NSchicht.Web.Dienste
{
    public class KategorieApiDienst
    {
        private readonly HttpClient _httpClient;

        public KategorieApiDienst(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<KategorieDüo>> GehZurAlleDaten()
        {
            var antwort = await _httpClient.GetFromJsonAsync<BenutzerDefinierteAntwortDüo<List<KategorieDüo>>>("kategorien");
            return antwort.Daten;
        }
    }
}
