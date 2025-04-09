using NSchicht.Kern.DÜOe;

namespace NSchicht.Web.Dienste
{
    public class ProduktApiDienst
    {
        private readonly HttpClient _httpClient;

        public ProduktApiDienst(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ProduktMitKategorieDüo>> RufProdukteMitKategorie()
        {
            var antwort = await _httpClient.GetFromJsonAsync<BenutzerDefinierteAntwortDüo<List<ProduktMitKategorieDüo>>>("produkte/RufProdukteMitKategorie");

            return antwort.Daten;
        }

        public async Task<ProduktDüo> GehZurIDAsync(int ID)
        {

            var antwort = await _httpClient.GetFromJsonAsync<BenutzerDefinierteAntwortDüo<ProduktDüo>>($"produkte/{ID}");
            return antwort.Daten;


        }

        public async Task<ProduktDüo> SpeichernAsync(ProduktDüo neuesProdukt)
        {
            var antwort = await _httpClient.PostAsJsonAsync("produkte", neuesProdukt);

            if (!antwort.IsSuccessStatusCode) return null;

            var antwortBody = await antwort.Content.ReadFromJsonAsync<BenutzerDefinierteAntwortDüo<ProduktDüo>>();

            return antwortBody.Daten;


        }
        public async Task<bool> AktualisierenAsync(ProduktDüo neuesProdukt)
        {
            var response = await _httpClient.PutAsJsonAsync("produkte", neuesProdukt);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> EntfernenAsync(int ID)
        {
            var antwort = await _httpClient.DeleteAsync($"produkte/{ID}");

            return antwort.IsSuccessStatusCode;
        }

    }
}
