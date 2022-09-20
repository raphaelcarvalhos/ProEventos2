using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos2.Domain;
using ProEventos2.Persistence.Contratos;
using ProEventos2.Persistence.Contextos;

namespace ProEventos2.Persistence
{
    public class EventoPersist : IEventoPersist
    {
        public ProEventos2Context _context;

        public EventoPersist(ProEventos2Context context)
        {
            _context = context;
            // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            
        }
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if (includePalestrantes){
                query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();

        }
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if (includePalestrantes){
                query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(e=> e.Tema.ToLower().Contains(tema.ToLower()));
            
            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if (includePalestrantes){
                query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(e=> e.Id == eventoId);
            
            return await query.FirstOrDefaultAsync();
        }
        
    }
}