using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Kern.Dienste
{
    public interface IDienst<T> where T : class
    {
        Task<T> GehZurIDAsync(int ID);
        Task<IEnumerable<T>> GehZurAlleDatenAsync();
        IQueryable<T> Wo(Expression<Func<T, bool>> expression);
        Task<bool> IrgendeinAsync(Expression<Func<T, bool>> expression);
        Task<T> InsertAsync(T einheit);
        Task<IEnumerable<T>> InsertFeldAsync(IEnumerable<T> einheiten);
        Task AktualisierenAsync(T einheit);
        Task EntfernenAsync(T einheit);
        Task EntfernenFeldAsync(IEnumerable<T> einheiten);
    }
}
