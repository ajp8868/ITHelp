namespace ITHelp_Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket_History
    {
        public int Id { get; set; }
        public int Ticket_Id { get; set; }
        public int Update_Num { get; set; }
        public string Description { get; set; }
        public int Status_Id { get; set; }
        public int Updated_By { get; set; }
        public System.DateTime Updated_On { get; set; }
        public int Urgency_Id { get; set; }
    
        public virtual Ticket_Statuses Ticket_Status { get; set; }
        public virtual Ticket_Urgencies Ticket_Urgency { get; set; }
    }
}
