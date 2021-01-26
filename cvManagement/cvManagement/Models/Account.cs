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
        public string Name { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }

        public Account() { }

        public Account(int id, string name, string password, string role)
        {
            Id = id;
            Name = name;
            PassWord = password;
            Role = role;
        }
    }
}