using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheWatchers.Models
{
    [Serializable]
    public class LoginModel
    {
        [Key]
        [Required]
        [DisplayName("User Name")]
        public int username { set; get; }
        [DisplayName("Password")]
        [Required]
        public string password { get; set;}
        [DisplayName("Remember Me")]
        public bool rememberme { get; set; }
    }
}