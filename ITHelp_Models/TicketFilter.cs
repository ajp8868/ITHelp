using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelp_Models
{
    public partial class TicketFilter
    {
        [Display(Name="Completed")]
        public bool? completed { get; set; }
        [Display(Name = "Awaiting Approval")]
        public bool? awaiting_approval { get; set; }
        [Display(Name = "Due In x Days:")]
        public int? day_limit { get; set; }
    }
}
