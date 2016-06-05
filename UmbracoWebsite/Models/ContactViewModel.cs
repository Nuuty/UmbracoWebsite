using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UmbracoWebsite.Models
{
    public class ContactViewModel
    {
        [Required]
        public String Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        [Display(Name = "Enter a message")]
        public String Message { get; set; }
    }
   
}