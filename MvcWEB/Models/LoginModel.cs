using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWEB.Models
{
    public class LoginModel
    {
       // [Required]
        public string UserName { set; get; }
        public string Pass { set; get; }
        public bool RememberMe { get; set; }
    }
}