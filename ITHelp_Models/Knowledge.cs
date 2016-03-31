namespace ITHelp_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Knowledge")]
    public partial class Knowledge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Knowledge()
        {
            Knowledge_Keywords = new HashSet<Knowledge_Keywords>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int Revision { get; set; }

        public int? Added_By { get; set; }

        [Column(TypeName = "date")]
        public DateTime Added_On { get; set; }

        [Column(TypeName = "date")]
        public DateTime Last_Updated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Knowledge_Keywords> Knowledge_Keywords { get; set; }
    }
}
