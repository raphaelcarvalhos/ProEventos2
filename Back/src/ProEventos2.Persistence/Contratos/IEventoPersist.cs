using System.Threading.Tasks;
using ProEventos2.Domain;

namespace ProEventos2.Persistence.Contratos
{
    public interface IEventoPersist
    {
        // //GERAL
        // void Add<T>(T entity) where T: class;
        // void Update<T>(T entity) where T: class;
        // void Delete<T>(T entity) where T: class;
        // void DeleteRange<T>(T[] entity) where T: class;
        // Task<bool> SaveChangesAsync();

        //EVENTOS
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);

        // //PALESTRANTES
        // Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        // Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        // Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos);
    }
}