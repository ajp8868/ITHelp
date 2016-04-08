//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITHelp_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            this.Ticket_History = new HashSet<Ticket_History>();
            this.Ticket_Keywords = new HashSet<Ticket_Keywords>();
        }

        public int Id { get; set; }
        public string Reference { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public System.DateTime Raised { get; set; }
        [Display(Name = "Status")]
        public int Status_Id { get; set; }
        [Display(Name = "Completed")]
        public Nullable<System.DateTime> Completed_On { get; set; }
        [Display(Name = "Urgency")]
        public int Urgency_Id { get; set; }
        [Display(Name = "Type")]
        public int Type_Id { get; set; }
        public int Raised_By { get; set; }
        public bool Needs_Approval { get; set; }
        public Nullable<int> Approved_By { get; set; }
        [Display(Name = "Date Required By")]
        [Required]
        public System.DateTime Required_By { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket_History> Ticket_History { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket_Keywords> Ticket_Keywords { get; set; }
        public virtual Ticket_Statuses Ticket_Status { get; set; }
        public virtual Ticket_Urgencies Ticket_Urgency { get; set; }
        public virtual User User_Approve { get; set; }
        public virtual User User_Raised { get; set; }
        public virtual Ticket_Types Ticket_Type { get; set; }
    }
}
