using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NSchicht.Kern.DÜOe
{
    public class BenutzerDefinierteAntwortDüo<T>
    {
        public T Daten { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<String> Fehler { get; set; }
        public static BenutzerDefinierteAntwortDüo<T> Erfolg(int statusCode, T daten)
        {
            return new BenutzerDefinierteAntwortDüo<T> { Daten = daten, StatusCode = statusCode };
        }
        public static BenutzerDefinierteAntwortDüo<T> Erfolg(int statusCode)
        {
            return new BenutzerDefinierteAntwortDüo<T> { StatusCode = statusCode };
        }
        public static BenutzerDefinierteAntwortDüo<T> Scheitern(int statusCode, List<string> fehler)
        {
            return new BenutzerDefinierteAntwortDüo<T> { StatusCode = statusCode, Fehler=fehler };
        }
        public static BenutzerDefinierteAntwortDüo<T> Scheitern(int statusCode, string fehler)
        {
            return new BenutzerDefinierteAntwortDüo<T> { StatusCode = statusCode, Fehler = new List<string> { fehler }};
        }
    }
}
