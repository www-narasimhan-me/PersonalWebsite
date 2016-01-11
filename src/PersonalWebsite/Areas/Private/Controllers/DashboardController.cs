﻿using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using PersonalWebsite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Areas.Private.Controllers
{
    [Authorize]
    [Area(nameof(Private))]
    public class DashboardController : Controller
    {
        public DashboardController(IPrivateDefaultsService privateDefaultsService)
        {
            if (privateDefaultsService == null)
            {
                throw new ArgumentNullException(nameof(privateDefaultsService));
            }

            privateDefaultsService.Setup();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
