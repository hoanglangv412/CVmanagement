using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cvManagement.Models
{
    public class emailTemplate
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public List<emailTemplate> listTemplate { get; set; }

        public emailTemplate() { }

        public emailTemplate(int id, string name, string content, List<emailTemplate> listTemplate)
        {
            Id = id;
            Name = name;
            Content = content;
            this.listTemplate = listTemplate;
        }
    }
}