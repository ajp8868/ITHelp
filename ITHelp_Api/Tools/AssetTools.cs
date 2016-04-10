using ITHelp_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * Tools required for working with assets.
 * @author Adam Postgate - M2095821
 * Email: ajp8868@aol.com
 */
namespace ITHelp_Api.Tools
{
    public static class AssetTools
    {
        public static Asset CheckById(int id, List<Asset> assets)
        {
            foreach (Asset a in assets)
            {
                if (a.Id == id)
                {
                    return a;
                }
            }

            return null;
        }
    }
}