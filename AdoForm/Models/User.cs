using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AdoForm.Models
{
    public class User
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MinLength(6,ErrorMessage="Your password must be at least 6 characters")]
        [RegularExpression("^(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$",ErrorMessage = "Your password must contain an upper and lower case character, and a number")]
        public string Password { get; set; }
    }
}