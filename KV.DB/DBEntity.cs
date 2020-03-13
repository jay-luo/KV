using System;
using KV.Entities.Models;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KV.DB
{
    public class DBEntity
    {
        [ThreadStatic]
        static  BookLibraryContext _context = null;
        public DBEntity() {
           if(_context==null) _context = new BookLibraryContext();
        }
        public void Insert<T>(T t) where T : class {
            _context.Set<T>().Add(t);
        }
        public void Delete<T>(T t)where T:class {
            _context.Set<T>().Remove(t);
        }
        public void Update<T>(T t) where T : class
        {
            _context.Set<T>().Update(t);
        }
        public IEnumerable<T> Query<T>()where T:class {
            return _context.Set<T>().AsEnumerable();
        }
        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
