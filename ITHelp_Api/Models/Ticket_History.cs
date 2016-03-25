namespace ITHelp_Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ticket_History
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Ticket_Id { get; set; }

        public int Update_Num { get; set; }

        [Required]
        public string Description { get; set; }

        public int Status_Id { get; set; }

        public int Updated_By { get; set; }

        public DateTime Updated_On { get; set; }

        public int Urgency_Id { get; set; }

        public virtual Ticket_Statuses Ticket_Statuses { get; set; }

        public virtual Ticket_Urgencies Ticket_Urgencies { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
