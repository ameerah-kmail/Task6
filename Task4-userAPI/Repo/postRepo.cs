﻿using Task4_userAPI.Contex;
using Task4_userAPI.Models;

namespace Task4_userAPI.Repo
{
    public interface IpostRepo : IGenRepo<post>
    {

    }
    public class postRepo :GenRepo<post>, IpostRepo
    {
        private MVCContext _context;
        public postRepo(MVCContext context) : base(context)
        {
            _context = context;

        }
      /*  public void add(post _post)
        {
            _context.Add<post>(_post);
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            post _temp = get(id);
            if (_temp != null)
            {
                _context.Remove<post>(_temp);
                _context.SaveChanges();

            }
        }

        public post get(int id)
        {
            post p;
            p = _context.Find<post>(id);
            return p;
            _context.SaveChanges();
        }
      */
        public  async  Task<List<post>> getAll()
        {
                return await  _context.posts.Include(c => c.userId).ToListAsync();
               // return _context.Set<post>().Include(c => c.users).ToList();
            // List<post> postList;

            // postList = _context.Set<post>().ToList();
            // return postList;
            // _context.SaveChanges();
        }
        /*
        public void update(post _post)
        {
            post _temp = get(_post.Id);
            if (_temp != null)
            {
                _temp.Title = _post.Title;
                
                _context.Update<post>(_temp);
                _context.SaveChanges();
            }*/
        
    }
}
