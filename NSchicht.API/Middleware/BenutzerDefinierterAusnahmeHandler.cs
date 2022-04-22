using Microsoft.AspNetCore.Diagnostics;
using NSchicht.Dienst.Ausnahmen;
using NSchicht.Kern.DÜOe;
using System.Text.Json;

namespace NSchicht.API.Middleware
{
    public static class BenutzerDefinierterAusnahmeHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {

                config.Run(async kontext =>
                {
                    kontext.Response.ContentType = "application/json";

                    var ausnahmeEigenschaft = kontext.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = ausnahmeEigenschaft.Error switch
                    {
                        ClientSeitigeAusnahme => 400,
                        AusnahmeNichtGefunden => 404,
                        _ => 500
                    };
                    kontext.Response.StatusCode = statusCode;


                    var antwort = BenutzerDefinierteAntwortDüo<KeinInhaltDüo>.Scheitern(statusCode, ausnahmeEigenschaft.Error.Message);


                    await kontext.Response.WriteAsync(JsonSerializer.Serialize(antwort));

                });
            });
        }
    }
}