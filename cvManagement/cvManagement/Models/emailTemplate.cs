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

        [Required(ErrorMessage = "Enter the email type")]
        [StringLength(50, ErrorMessage = "Name should be less than or equal to 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the content")]
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