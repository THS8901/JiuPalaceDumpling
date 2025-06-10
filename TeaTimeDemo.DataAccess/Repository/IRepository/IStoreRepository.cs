using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DumplingStore.Models;

namespace DumplingStore.DataAccess.Repository.IRepository
{
    public  interface IStoreRepository : IRepository<Store>
    {
        void Update(Store obj);
       // void Save();
    }
}
