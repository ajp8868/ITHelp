using ITHelp_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * All tools required for handling user entities
 * @author Adam Postgate - M2095821
 * Email: ajp8868@aol.com
 */
namespace ITHelp_Api.Tools
{
    public class UserTools
    {
        public static User checkById(int id, List<User> users)
        {
            User toReturn = null;

            foreach (User u in users)
            {
                if (u.Id == id)
                {
                    toReturn = u;
                }
            }

            return toReturn;
        }

        public static User checkByUsername(string username, List<User> users)
        {
            User toReturn = null;

            foreach (User u in users)
            {
                if (u.User_Name.Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    toReturn = u;
                }
            }

            return toReturn;
        }
    }
}