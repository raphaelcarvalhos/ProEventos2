using System.Threading.Tasks;
using ProEventos2.Persistence.Contratos;
using ProEventos2.Persistence.Contextos;

namespace ProEventos2.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        public ProEventos2Context _context;

        public GeralPersist(ProEventos2Context context)
        {
            _context = context;
            
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);

        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        
    }
}