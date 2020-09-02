using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectBank.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public int Acno { get; set; }

        public int Amount { get; set; }

        public string TransactionType { get; set; }

        public DateTime TimeOfTransaction { get; set; }
    }
}