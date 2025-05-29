using Microsoft.EntityFrameworkCore;
using repaso_pais_api.Models;
using repaso_pais_api.Utils;

namespace repaso_pais_api.BLL
{
    public class TablapaiService : ITablapaiService
    {
        private readonly paisContext _context;
        public TablapaiService(paisContext context)
        {
            _context = context;
        }

        public async Task<Tablapai> DeleteTablaPais(int id)
        {
            var pais = await _context.Tablapais.FirstOrDefaultAsync(p => p.Id == id);
            if(pais == null)
            {
                return new Tablapai();
            }
            _context.Tablapais.Remove(pais);
            await _context.SaveChangesAsync();
            return pais;
        }

        public async Task<List<Tablapai>> GetTabs()
        {
            var lpais = await _context.Tablapais.AsNoTracking().ToListAsync();
            return lpais ?? new List<Tablapai>();
        }

        public async Task<Tablapai> PostTablaPais(Tablapai tpais)
        {
            await _context.Tablapais.AddAsync(tpais);
            await _context.SaveChangesAsync();
            return tpais;
        }

        public async Task<Tablapai> PutTablaPais(int idpais, Tablapai tablapai)
        {
            var model = await Tablapais(idpais);
            if (model == null || idpais == 0 || idpais != tablapai.Id)
            {
                return new Tablapai();
            }
            var entity = _context.Set<Tablapai>().Update(tablapai);
            entity.Property(x => x.Id).IsModified = false;
            await _context.SaveChangesAsync();
            return tablapai;
        }

        public async Task<Tablapai> Tablapais(int id)
        {
            var pais = await _context.Tablapais.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return pais ?? new Tablapai();
        }
    }
}
