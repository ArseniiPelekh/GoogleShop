using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interface;
using googleShop.ViewModes;
using Microsoft.AspNetCore.Mvc;

namespace googleShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourse _corRep;

        public HomeController(ICourse repository)
        {
            _corRep = repository;
        }

        public ViewResult Index()
        {
            var homeCourse = new HomeViewModel
            {
                courses = _corRep.Courses
            };
            return View(homeCourse);
        }
    }
}