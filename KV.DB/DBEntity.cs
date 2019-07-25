using System;
using KV.Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace KV.DB
{
    public class DBEntity:BookLibraryContext
    {
        public new void Add<T>(T t)where T:class {
            Insert(t);
        }
    }
}
