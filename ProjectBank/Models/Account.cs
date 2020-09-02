using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectBank.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Acno { get; set; }

        [Required]
        [Range(100,20000)]
        public int Amount { get; set; }
    }
}