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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }



        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id ==obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Size = obj.Size;
                objFromDb.Price = obj.Price;
                objFromDb.Description = obj. Description;
                objFromDb.CategoryId = obj.CategoryId;
                if (objFromDb.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
              //  _db.Products.Update(obj);
        }
    }
}
