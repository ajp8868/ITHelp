namespace ITHelp_Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Asset
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asset()
        {
            Asset_Tickets = new HashSet<Asset_Tickets>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Type_Id { get; set; }

        public int Location_Id { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Bought { get; set; }

        public int? Supplier_Id { get; set; }

        public virtual Asset_Suppliers Asset_Suppliers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset_Tickets> Asset_Tickets { get; set; }

        public virtual Asset_Types Asset_Types { get; set; }

        public virtual Location Location { get; set; }
    }
}
