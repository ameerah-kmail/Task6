using Task4_userAPI.Repo;
namespace Task4_userAPI.Repo
{

    public interface IGenRepo<T> where T:class , IbaseMode
    {
        public Task<List<T>>? getAll();
        public Task<T> get(int id);
        public void delete(int id);
        public Task<T> update(T _obj);
        public Task<T> add(T _obj);
    }
    public class GenRepo<T> : IGenRepo<T> where T : class, IbaseMode
    {
        readonly MVCContext _context;
        public GenRepo(MVCContext context)
        {
            _context = context;
        }
        async public Task<T> add(T _obj)
        { 
            await _context.AddAsync(_obj);
            await _context.SaveChangesAsync();
            return _obj;
        }

         async public void delete(int id)
        {
            var _temp =await _context.Set<T>().FirstOrDefaultAsync(c => c.Id==id);
             _context.Set<T>().Remove(_temp);
            await _context.SaveChangesAsync();

        }

        public Task<T> get(int id)
        {

            return _context.Set<Task<T>>().Find(id);
            _context.SaveChangesAsync();
        }

        async public Task<List<T>>? getAll()
        {
            return _context.Set<T>().ToList();

            _context.SaveChangesAsync();
        }

        async public  Task<T> update(T _obj)
        {
            _context.Set<T>().Update(_obj);
               // .Update<T>(_obj);
            return _obj;
            _context.SaveChangesAsync();
        }

      
    }
}

