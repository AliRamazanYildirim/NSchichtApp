using Microsoft.EntityFrameworkCore;
using NSchicht.Kern.Quellen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Quelle.Quellen
{
    public class GenerischeQuelle<T> : IGenerischeQuelle<T> where T : class
    {
        protected readonly AppDbKontext _kontext;
        private readonly DbSet<T> _dbSet;

        public GenerischeQuelle(AppDbKontext kontext)
        {
            _kontext = kontext;
            _dbSet = _kontext.Set<T>();
            
        }

        public void Aktualisieren(T einheit)
        {
            _dbSet.Update(einheit);
        }

        public void Entfernen(T einheit)
        {
            _dbSet.Remove(einheit);
        }

        public void EntfernenFeld(IEnumerable<T> einheiten)
        {
            _dbSet.RemoveRange(einheiten);
        }

        public IQueryable<T> GehZurAlleDaten()//
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GehZurIDAsync(int ID)
        {
            return await _dbSet.FindAsync(ID);
        }

        public async Task InsertAsync(T einheit)
        {
            await _dbSet.AddAsync(einheit);
        }

        public async Task InsertFeldAsync(IEnumerable<T> einheiten)
        {
            await _dbSet.AddRangeAsync(einheiten);
        }

        public async Task<bool> IrgendeinAsync(Expression<Func<T, bool>> expression)
        {
           return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<T> Wo(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
