using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BnSystem_Test.Models;
using BnSystem_Test.Models.Repositorys;
using BnSystem_Test.Models.Services;
using BnSystem_Test.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BnSystem_Test.Controllers.APIControllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class aAccountController : ControllerBase
    {
        private readonly IDataRepository<Accounts> _AccountsRepository;
        private readonly IDataRepository<AccTransfers> _AccTransfersRepository;

        public aAccountController(IDataRepository<Accounts> dataRepository, IDataRepository<AccTransfers> AccTransfersRepository)
        {
            _AccountsRepository = dataRepository;
            _AccTransfersRepository = AccTransfersRepository;
        }
        //Post
        //Created Account with first amount
        [HttpPost]
        public Account CreateAccount(vAccount_obj_save ItemData)
        {
            Account objResult = new Account();
            var Data = _AccountsRepository.GetAll();
            if (Data.Any(a => a.IBAN == (ItemData.IBAN + "").Trim()))
            {
                objResult.Msg = "Dulpication IBAN";


                return objResult;
            }

            if (!ItemData.amount.HasValue)
            {
                objResult.Msg = "amount is null or zero.";
                return objResult;
            }

            DateTime dNow = DateTime.Now;
            Accounts objSave = new Accounts()
            {
                update_user = "Admin",
                update_date = dNow,
                create_user = "Admin",
                create_date = dNow,
                active_status = "Y",
                IBAN = (ItemData.IBAN + "").Trim(),
                AccTransfers = new List<AccTransfers>(),
                balance = ItemData.amount.Value * (decimal)0.99,
            };
            objSave.AccTransfers.Add(new AccTransfers
            {
                update_user = "Admin",
                update_date = dNow,
                create_user = "Admin",
                create_date = dNow,
                active_status = "Y",
                Amount = ItemData.amount.Value * (decimal)0.99,
                is_calculated = "Y",
                action_type = "D"
            });

            _AccountsRepository.Add(objSave);

            objResult.Data = new List<Account>() { };
            Data = _AccountsRepository.GetAll().ToList();
            return objResult;
        }

        //Tranfer Balance 
        [HttpPost]
        public Account TranferMoney(vAccount_obj_save ItemData)
        {
            DateTime dNow = DateTime.Now;
            Account objResult = new Account();
            var Data = _AccountsRepository.GetAll();
            if (!Data.Any(a => a.Id == ItemData.Id) || !Data.Any(a => a.Id == ItemData.IdTo))
            {
                objResult.Msg = "Account not found.";
                return objResult;
            }
            var accUser = Data.Where(w => w.Id == ItemData.Id).FirstOrDefault();
            var accTo = Data.Where(w => w.Id == ItemData.IdTo).FirstOrDefault();
            if (!ItemData.amount.HasValue)
            {
                objResult.Msg = "amount is null or zero.";
                return objResult;
            }
            if (accUser.balance < ItemData.amount)
            {
                objResult.Msg = "Unable to perform list.";
                return objResult;
            }

            var objUser = new AccTransfers
            {
                update_user = "Admin",
                update_date = dNow,
                create_user = "Admin",
                create_date = dNow,
                active_status = "Y",
                Amount = ItemData.amount.Value,
                is_calculated = "Y",
                action_type = "T",
                Accounts_Id = ItemData.Id

            };

            var objTo = new AccTransfers
            {
                update_user = "Admin",
                update_date = dNow,
                create_user = "Admin",
                create_date = dNow,
                active_status = "Y",
                Amount = ItemData.amount.Value,
                is_calculated = "Y",
                action_type = "D",
                Accounts_Id = ItemData.IdTo

            };

            _AccTransfersRepository.Add(objUser);
            _AccTransfersRepository.Add(objTo);
            accUser.update_date = dNow;
            accUser.update_user = "Admin";
            accUser.balance = accUser.balance - ItemData.amount.Value;

            accTo.update_date = dNow;
            accTo.update_user = "Admin";
            accTo.balance = accUser.balance + ItemData.amount.Value;

            _AccountsRepository.Update(accUser, accUser);
            _AccountsRepository.Update(accTo, accUser);

            objResult.Data = new List<Account>() { };
            Data = _AccountsRepository.GetAll().ToList();
            return objResult;
        }

        //Withdrawal Balance 
        [HttpPost]
        public Account Withdrawal(vAccount_obj_save ItemData)
        {
            DateTime dNow = DateTime.Now;
            Account objResult = new Account();
            var Data = _AccountsRepository.GetAll();
            if (!Data.Any(a => a.Id == ItemData.Id))
            {
                objResult.Msg = "Account not found.";
                return objResult;
            }
            var accUser = Data.Where(w => w.Id == ItemData.Id).FirstOrDefault();
            if (!ItemData.amount.HasValue)
            {
                objResult.Msg = "amount is null or zero.";
                return objResult;
            }
            if (accUser.balance < ItemData.amount)
            {
                objResult.Msg = "Unable to perform list.";
                return objResult;
            }

            var objUser = new AccTransfers
            {
                update_user = "Admin",
                update_date = dNow,
                create_user = "Admin",
                create_date = dNow,
                active_status = "Y",
                Amount = ItemData.amount.Value,
                is_calculated = "Y",
                action_type = "W",
                Accounts_Id = ItemData.Id

            };

            _AccTransfersRepository.Add(objUser);
            accUser.update_date = dNow;
            accUser.update_user = "Admin";
            accUser.balance = accUser.balance - ItemData.amount.Value;

            _AccountsRepository.Update(accUser, accUser);

            objResult.Data = new List<Account>() { };
            Data = _AccountsRepository.GetAll().ToList();
            return objResult;
        }

        //Withdrawal Balance 
        [HttpPost]
        public Account Deposit(vAccount_obj_save ItemData)
        {
            DateTime dNow = DateTime.Now;
            Account objResult = new Account();
            var Data = _AccountsRepository.GetAll();
            if (!Data.Any(a => a.Id == ItemData.Id))
            {
                objResult.Msg = "Account not found.";
                return objResult;
            }
            var accUser = Data.Where(w => w.Id == ItemData.Id).FirstOrDefault();
            if (!ItemData.amount.HasValue)
            {
                objResult.Msg = "amount is null or zero.";
                return objResult;
            }
            

            var objUser = new AccTransfers
            {
                update_user = "Admin",
                update_date = dNow,
                create_user = "Admin",
                create_date = dNow,
                active_status = "Y",
                Amount = ItemData.amount.Value,
                is_calculated = "Y",
                action_type = "D",
                Accounts_Id = ItemData.Id

            };

            _AccTransfersRepository.Add(objUser);
            accUser.update_date = dNow;
            accUser.update_user = "Admin";
            accUser.balance = accUser.balance + ItemData.amount.Value;

            _AccountsRepository.Update(accUser, accUser);

            objResult.Data = new List<Account>() { };
            Data = _AccountsRepository.GetAll().ToList();
            return objResult;
        }
    }
}