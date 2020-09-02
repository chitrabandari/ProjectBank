using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectBank.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name e.g. John Doe")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string RetypePassword { get; set; }

        [Required]
        public int Acno { get; set; }

        //[Required]
        //[DisplayName("Mobile Number")]
        public string Phoneno { get; set; }

        [Range(18,100)]
        public int Age { get; set; }

        [StringLength(35)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        //[Required]
        [Range(500,20000)]
        public int IniAmount { get; set; }



    }
}