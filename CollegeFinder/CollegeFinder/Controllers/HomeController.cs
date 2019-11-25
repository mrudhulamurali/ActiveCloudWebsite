using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CollegeFinder.Models;
using CollegeFinder.APIHandlerManager;
using CollegeFinder.DataAccess;

namespace CollegeFinder.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            dbContext = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
         {
            
            var collegename = dbContext.Colleges.ToList();
            return View(collegename);
        }
        public IActionResult collegepage(string id)
        {
            College univ = dbContext.Colleges
                                   .Where(c => c.collegeName == id)
                                   .First();

            APIHandler webHandler = new APIHandler();
            Rootobject college = webHandler.GetCollegeDetails(univ.id);

            return View(college.results[0]);
        }

        public IActionResult popularpage()
        {
            College univ1 = dbContext.Colleges.FirstOrDefault();
            College value = new College();

            APIHandler webHandler = new APIHandler();
            Rootobject popular = webHandler.popularcollegelist();

            if (univ1 == null)
            {
                foreach (var result in popular.results)
                {
                    value.id = result.id;
                    value.collegeName = result.school.name;
                    dbContext.Colleges.Add(value);
                    dbContext.SaveChanges();
                }

            }

            return View(popular.results);
        }

        public IActionResult About_Us()
        {
            return View();
        }
        public IActionResult Chart()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
