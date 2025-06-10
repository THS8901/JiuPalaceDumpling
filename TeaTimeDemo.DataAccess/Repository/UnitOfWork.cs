using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DumplingStore.DataAccess.Data;
using DumplingStore.DataAccess.Repository.IRepository;
using DumplingStore.Models;

namespace DumplingStore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category {get; private set; }
        public IProductRepository Product { get; private set; }
        public IStoreRepository Store {get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Store = new StoreRepository(_db);
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
