using BnSystem_Test.Models.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BnSystem_Test.Models.Services
{
    public interface IAccounts
    {
        IEnumerable<Accounts> GetByID(string sID);
    }

    public class AccountsService : IDataRepository<Accounts>
    {
        readonly StoreDb _StoreDb;

        public AccountsService(StoreDb context)
        {
            _StoreDb = context;
        }

        public IEnumerable<Accounts> GetAll()
        {
            return _StoreDb.Accounts.ToList();
        }
        public IEnumerable<Accounts> GetByID(string sID)
        {
            return _StoreDb.Accounts.Where(w => w.IBAN.Contains(sID + "")).ToList();
        }

        public Accounts Get(long id)
        {
            return _StoreDb.Accounts
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Accounts entity)
        {
            _StoreDb.Accounts.Add(entity);
            _StoreDb.SaveChanges();
        }

        public void Update(Accounts Account, Accounts entity)
        {
            _StoreDb.SaveChanges();
        }

        public void Delete(Accounts Accounts)
        {
            _StoreDb.Accounts.Remove(Accounts);
            _StoreDb.SaveChanges();
        }


    }
}
