using ITHelp_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
 * All methods required for working with knowledge
 * @author Adam Postgate - M2095821
 * Email: ajp8868@aol.com
 */
namespace ITHelp_Api.Tools
{
    public class KnowledgeTools
    {
        public static List<Knowledge> CheckBySearch(string search, List<Knowledge> knowledge)
        {
            if (search.Length == 0) {
                return knowledge;
            }

            List<Knowledge> toReturn = new List<Knowledge>();
            string ss = search.ToString().Replace("%20", " ").ToLower();

            foreach (Knowledge kn in knowledge)
            {
                foreach (string s in ss.Split(' '))
                {
                    if (kn.Description.ToLower().Contains(s) || kn.Title.ToLower().Contains(s))
                    {
                        toReturn.Add(kn);
                    }
                    else
                    {
                        foreach (Knowledge_Keywords kw in kn.Knowledge_Keywords)
                        {
                            if (kw.Keyword.Keyword1.ToLower().Contains(s))
                            {
                                toReturn.Add(kn);
                            }
                        }
                    }
                }
            }

            return toReturn.Distinct().ToList();
        }

        public static Knowledge CheckById(int id, List<Knowledge> knowledge)
        {
            foreach (Knowledge kn in knowledge)
            {
                if (kn.Id == id)
                {
                    return kn;
                }
            }

            return null;
        }
    }
}