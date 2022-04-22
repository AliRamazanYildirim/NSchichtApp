using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NSchicht.Kern;
using NSchicht.Kern.Dienste;
using NSchicht.Kern.DÜOe;

namespace NSchicht.API.Filter
{
    public class FilterNichtGefunden<T> : IAsyncActionFilter where T : BasisEinheit
    {
        private readonly IDienst<T> _dienst;

        public FilterNichtGefunden(IDienst<T> dienst)
        {
            _dienst = dienst;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var IDWert = context.ActionArguments.Values.FirstOrDefault();

            if (IDWert == null)
            {
                await next.Invoke();
                return;
            }

            var ID = (int)IDWert;
            var irgendeinEinheit = await _dienst.IrgendeinAsync(x => x.ID == ID);

            if (irgendeinEinheit)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(BenutzerDefinierteAntwortDüo<KeinInhaltDüo>.Scheitern(404, $"{typeof(T).Name}({ID}) wurde nicht gefunden"));
        }
    }
}
