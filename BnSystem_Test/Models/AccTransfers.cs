using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BnSystem_Test.Models
{
    public class AccTransfers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public decimal Amount { get; set; }

        [StringLength(10)]
        public string active_status { get; set; }
        public DateTime? create_date { get; set; }
        [StringLength(50)]
        public string create_user { get; set; }
        public DateTime? update_date { get; set; }
        [StringLength(50)]
        public string update_user { get; set; }
        public int? Accounts_Id { get; set; }
        [ForeignKey("Accounts_Id")]
        public virtual Accounts Accounts { get; set; }

        [StringLength(10)]
        public string is_calculated { get; set; }
        //
        //Type of action
        //
        //
        [StringLength(10)]
        public string action_type { get; set; }
    }
}
