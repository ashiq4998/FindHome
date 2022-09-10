using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserLogin
    {
     
        [Required(AllowEmptyStrings =false, ErrorMessage ="Email ID required")]
        public string EmailID { get; set; }

     
        [Required(AllowEmptyStrings =false, ErrorMessage ="Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}