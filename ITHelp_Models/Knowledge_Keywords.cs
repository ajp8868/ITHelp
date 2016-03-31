namespace ITHelp_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Knowledge_Keywords
    {
        public int Knowledge_Id { get; set; }

        public int Keyword_Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public virtual Keyword Keyword { get; set; }

        public virtual Knowledge Knowledge { get; set; }
    }
}
