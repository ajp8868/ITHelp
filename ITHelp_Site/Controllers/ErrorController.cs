﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ITHelp_Site.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View("AdminError");
        }
    }
}