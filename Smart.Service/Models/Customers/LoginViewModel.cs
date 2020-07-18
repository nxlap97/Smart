using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Smart.Service.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
