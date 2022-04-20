using System.Linq.Expressions;

namespace NSchicht.Kern.Quellen
{
    public interface IGenerischeQuelle<T> where T : class
    {
        Task<T> GehZurIDAsync(int ID);
        IQueryable<T> GehZurAlleDaten(Expression<Func<T, bool>> expression);
        IQueryable<T> Wo(Expression<Func<T, bool>> expression);
        Task<bool> IrgendeinAsync(Expression<Func<T, bool>> expression);
        Task InsertAsync(T einheit);
        Task InsertFeldAsync(IEnumerable<T> einheiten);
        void Aktualisieren();
        void Entfernen();
        void EntfernenFeld(IEnumerable<T> einheiten);


    }
}
