using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cvManagement.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Your Name")]
        [StringLength(50, ErrorMessage = "Name should be less than or equal to 50 characters.")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Enter Your Password")]
        //[StringLength(50, ErrorMessage = "Password should be less than or equal to 50 characters.")]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "Choose the role")]
        public int Role { get; set; }

        public List<Account> listAccount;

        public Account account;
        public Account() { }

        public Account(int id, string name, string password, int role)
        {
            Id = id;
            Name = name;
            PassWord = password;
            Role = role;
        }
    }
}