﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BnSystem_Test.Models
{
    public class Accounts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(20)]
        public string IBAN { get; set; }
        [StringLength(10)]
        public string active_status { get; set; }
        public DateTime? create_date { get; set; }
        [StringLength(50)]
        public string create_user { get; set; }
        public DateTime? update_date { get; set; }
        [StringLength(50)]
        public string update_user { get; set; }
        public virtual ICollection<AccTransfers> AccTransfers { get; set; }

        public decimal? balance { get; set; }
    }
}
