using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSchicht.Kern.DÜOe;

namespace NSchicht.API.Controllers
{
    
    public class BenutzerDefinierteBasisController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(BenutzerDefinierteAntwortDüo<T> antwort)
        {
            if (antwort.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = antwort.StatusCode
                };
            return new ObjectResult(antwort)
            {
                StatusCode = antwort.StatusCode
            };
        }
    }
}
