using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BnSystem_Test.ViewModels
{
    public class Account : CResutlWebMethod
    {
        public List<Account> Data { get; set; }
    }
    public class vAccount_obj_save
    {
        public int? Id { get; set; }
        public string IdEncrypt { get; set; } 
        public string IBAN { get; set; }
        public decimal? amount { get; set; }
        public int? IdTo { get; set; }
    }
    public class CResutlWebMethod
    {
        public string Status { get; set; }
        public string Msg { get; set; }
        public string Content { get; set; }
        public string Content1 { get; set; }
        public string[] ArrContent { get; set; }
        public string[] ArrContent1 { get; set; }
        public string[] ArrContent2 { get; set; }
    }
}
