using BnSystem_Test.Models.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BnSystem_Test.Models.Services
{
    public class AccTransfersService : IDataRepository<AccTransfers>
    {
        readonly StoreDb _StoreDb;

        public AccTransfersService(StoreDb context)
        {
            _StoreDb = context;
        }

        public IEnumerable<AccTransfers> GetAll()
        {
            return _StoreDb.AccTransfers.ToList();
        }
       
        public AccTransfers Get(long id)
        {
            return _StoreDb.AccTransfers
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(AccTransfers entity)
        {
            _StoreDb.AccTransfers.Add(entity);
            _StoreDb.SaveChanges();
        }

        public void Update(AccTransfers Account, AccTransfers entity)
        {
            _StoreDb.SaveChanges();
        }

        public void Delete(AccTransfers AccTransfers)
        {
            _StoreDb.AccTransfers.Remove(AccTransfers);
            _StoreDb.SaveChanges();
        }

    }
}
