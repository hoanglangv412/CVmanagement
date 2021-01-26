using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cvManagement.Models
{
    public class Source
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public Source() { }

        public Source(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}