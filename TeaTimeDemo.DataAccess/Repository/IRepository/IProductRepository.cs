using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DumplingStore.Models;

namespace DumplingStore.DataAccess.Repository.IRepository
{
    public  interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
       // void Save();
    }
}
