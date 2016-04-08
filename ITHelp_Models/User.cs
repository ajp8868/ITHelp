namespace ITHelp_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="User Name")]
        public string User_Name { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Enabled { get; set; }
        public bool Admin { get; set; }
        public string User_Group { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name="Phone Number")]
        public string Phone_No { get; set; }
    }
}
