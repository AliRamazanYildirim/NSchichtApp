using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Kern.Quellen
{
    public interface IKategorieQuelle:IGenerischeQuelle<Kategorie>
    {
        Task<Kategorie> RufEinzigeKategorieZurIDMitProdukteAsync(int KategorieID);

    }
}
