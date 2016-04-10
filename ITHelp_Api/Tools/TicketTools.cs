using ITHelp_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

/*
 * All tools required for working with tickets. Adds filtering by id and user and other helpful methods
 * @author Adam Postgate - M2095821
 * Email: ajp8868@aol.com
 */
namespace ITHelp_Api.Tools
{
    public class TicketTools
    {
        public static Ticket checkById(int id, List<Ticket> tickets)
        {
            foreach (Ticket ti in tickets)
            {
                if (ti.Id == id)
                {
                    return ti;
                }
            }

            return null;
        }

        public static List<Ticket> checkByUser(string user, List<Ticket> tickets)
        {
            List<Ticket> toReturn = new List<Ticket>();

            foreach (Ticket ti in tickets)
            {
                if (ti.User_Raised.User_Name.Equals(user, StringComparison.OrdinalIgnoreCase))
                {
                    toReturn.Add(ti);
                }
            }

            return toReturn;
        }

        public static List<Ticket> checkByFilter(TicketFilter filter, List<Ticket> tickets)
        {
            var toRemove = new List<Ticket>();
            var toReturn = tickets;

            foreach (Ticket ti in tickets)
            {
                if (filter.completed.HasValue && ti.Ticket_Status.Complete != filter.completed.GetValueOrDefault())
                {
                    toRemove.Add(ti);
                }
                if (filter.day_limit.HasValue && DateTime.Compare(ti.Required_By, DateTime.Now.AddDays(filter.day_limit.GetValueOrDefault())) > 0)
                {
                    toRemove.Add(ti);
                }
                if (filter.awaiting_approval.HasValue && ti.Needs_Approval != filter.awaiting_approval.GetValueOrDefault())
                {
                    toRemove.Add(ti);
                }
            }

            foreach(Ticket ti in toRemove)
            {
                toReturn.Remove(ti);
            }

            return toReturn;
        }

        public static void CreateHistory(ServiceConnector sc, Ticket ticket) {
            var th = new Ticket_History();

            th.Description = ticket.Description;
            th.Status_Id = ticket.Status_Id;
            th.Ticket_Id = ticket.Id;
            th.Urgency_Id = ticket.Urgency_Id;
            th.Updated_On = DateTime.Now;
            th.Update_Num = ticket.Ticket_History.Count + 1;
            th.Updated_By = (int)ticket.Raised_By;

            var x = sc.PostTicketHistoryAsync(th).Result;
        }
    }
}