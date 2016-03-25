namespace ITHelp_Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ticket_Keywords
    {
        public int Ticket_Id { get; set; }

        public int Keyword_Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public virtual Keyword Keyword { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
