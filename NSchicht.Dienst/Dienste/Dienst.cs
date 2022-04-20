using Microsoft.EntityFrameworkCore;
using NSchicht.Kern.ArbeitsEinheiten;
using NSchicht.Kern.Dienste;
using NSchicht.Kern.Quellen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Dienst.Dienste
{
    public class Dienst<T> : IDienst<T> where T : class
    {
        private readonly IGenerischeQuelle<T> _generischeQuelle;
        private readonly IArbeitsEinheit _arbeitsEinheit;

        public Dienst(IArbeitsEinheit arbeitsEinheit, IGenerischeQuelle<T> generischeQuelle)
        {
            _arbeitsEinheit = arbeitsEinheit;
            _generischeQuelle = generischeQuelle;
        }

        public async Task AktualisierenAsync(T einheit)
        {
            _generischeQuelle.Aktualisieren(einheit);
            await _arbeitsEinheit.VerpflichtenAsync();
        }

        public async Task EntfernenAsync(T einheit)
        {
            _generischeQuelle.Entfernen(einheit);
            await _arbeitsEinheit.VerpflichtenAsync();
        }

        public async Task EntfernenFeldAsync(IEnumerable<T> einheiten)
        {
            _generischeQuelle.EntfernenFeld(einheiten);
            await _arbeitsEinheit.VerpflichtenAsync();
        }

        public async Task<IEnumerable<T>> GehZurAlleDatenAsync()
        {
            return await _generischeQuelle.GehZurAlleDaten().ToListAsync();
        }

        public async Task<T> GehZurIDAsync(int ID)
        {
            return await _generischeQuelle.GehZurIDAsync(ID);
        }

        public async Task<T> InsertAsync(T einheit)
        {
            await _generischeQuelle.InsertAsync(einheit);
            await _arbeitsEinheit.VerpflichtenAsync();
            return einheit;
        }

        public Task<IEnumerable<T>> InsertFeldAsync(IEnumerable<T> einheiten)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IrgendeinAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Wo(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
/*
 public async Task AktualisierenAsync(T einheit)
        {
            
        }

        public async Task EntfernenAsync(T einheit)
        {
           
        }

        public async Task EntfernenFeldAsync(IEnumerable<T> einheiten)
        {
            
        }

        public async Task<IEnumerable<T>> GehZurAlleDatenAsync()
        {
            
        }

        public async Task<T> GehZurIDAsync(int ID)
        {
            
        }

        public async Task<T> InsertAsync(T einheit)
        {
            
        }

        public async Task<IEnumerable<T>> InsertFeldAsync(IEnumerable<T> einheiten)
        {
            await _generischeQuelle.InsertFeldAsync(einheiten);
            await _arbeitsEinheit.VerpflichtenAsync();
            return einheiten;
        }

        public async Task<bool> IrgendeinAsync(Expression<Func<T, bool>> expression)
        {
            return await _generischeQuelle.IrgendeinAsync(expression);
        }

        public IQueryable<T> Wo(Expression<Func<T, bool>> expression)
        {
            return _generischeQuelle.Wo(expression);
        }
 */