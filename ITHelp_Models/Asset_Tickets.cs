namespace ITHelp_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Asset_Tickets
    {
        public int Asset_Id { get; set; }

        public int Ticket_Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Asset Asset { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
