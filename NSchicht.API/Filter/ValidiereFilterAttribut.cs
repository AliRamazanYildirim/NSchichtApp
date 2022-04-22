using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NSchicht.Kern.DÜOe;

namespace NSchicht.API.Filter
{
    public class ValidiereFilterAttribut:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext kontext)
        {
            if (!kontext.ModelState.IsValid)
            {
                var fehler = kontext.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

                kontext.Result = new BadRequestObjectResult(BenutzerDefinierteAntwortDüo<KeinInhaltDüo>.Scheitern(400, fehler));
            }
        }
    }
}
