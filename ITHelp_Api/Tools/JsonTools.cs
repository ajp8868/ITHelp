using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

/*
 * Tools required for working with JSON. these get returned to anything that calls the api.
 * @author Adam Postgate - M2095821
 * Email: ajp8868@aol.com
 */
namespace ITHelp_Api
{
    public class JsonTools
    {
        public static JsonResult UnsuccessfulJson(string error)
        {
            JsonResult json = new JsonResult();
            json.Data = new { success = false, error = error };
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }

        public static JsonResult SuccessfulJson(object result)
        {
            JsonResult json = new JsonResult();
            json.Data = result;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            json.ContentType = "application/json";
            return json;
        }
    }
}