namespace ITHelp_Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            Asset_Tickets = new HashSet<Asset_Tickets>();
            Ticket_History = new HashSet<Ticket_History>();
            Ticket_Keywords = new HashSet<Ticket_Keywords>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Reference { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public DateTime Raised { get; set; }

        public int Status_Id { get; set; }

        public DateTime? Completed_On { get; set; }

        public int Urgency_Id { get; set; }

        public int Type_Id { get; set; }

        public int Raised_By { get; set; }

        public bool Needs_Approval { get; set; }

        public int? Approved_By { get; set; }

        [Column(TypeName = "date")]
        public DateTime Required_By { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset_Tickets> Asset_Tickets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket_History> Ticket_History { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket_Keywords> Ticket_Keywords { get; set; }

        public virtual Ticket_Statuses Ticket_Statuses { get; set; }

        public virtual Ticket_Types Ticket_Types { get; set; }

        public virtual Ticket_Urgencies Ticket_Urgencies { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
