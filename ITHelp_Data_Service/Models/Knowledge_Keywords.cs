//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITHelp_Data_Service.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Knowledge_Keywords
    {
        public int Knowledge_Id { get; set; }
        public int Keyword_Id { get; set; }
        public int Id { get; set; }
    
        public virtual Keyword Keyword { get; set; }
    }
}
