using ITHelp_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITHelp_Api.Tools
{
    public class TicketTools
    {
        public static Ticket checkById(int id, List<Ticket> tickets)
        {
            Ticket toReturn = null;

            foreach (Ticket ti in tickets)
            {
                if (ti.Id == id)
                {
                    toReturn = ti;
                }
            }

            return toReturn;
        }

        public static Ticket checkByUser(string user, List<Ticket> tickets)
        {
            Ticket toReturn = null;

            foreach (Ticket ti in tickets)
            {
                if (ti.User_Raised.User_Name == user)
                {
                    toReturn = ti;
                }
            }

            return toReturn;
        }
    }
}