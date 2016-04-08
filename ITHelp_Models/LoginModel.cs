namespace ITHelp_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class LoginModel
    {
        [Display(Name = "User Name")]
        public string User_Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}