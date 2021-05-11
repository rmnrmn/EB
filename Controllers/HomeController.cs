using EB.Services;
using EB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModels model = new HomeViewModels();

            AccomodationTypesService service = new AccomodationTypesService();

            model.AccomodationTypes = service.GetAllAccomodationTypes();

            return View();
        }
        
        public ActionResult Contact()
        {
            return View();
        }
       
        public ActionResult About()
        {
            return View();
        }
       
        public ActionResult Hotels(string location, string Hotel)
        {
            HotelsViewModels model = new HotelsViewModels();
            model.location = location;
            return View();
        }
        
        public ActionResult Search(string location, string Hotel)
        {
            SearchViewModels model = new SearchViewModels();
            model.location = location;
            return View();
        }
        
        public ActionResult Book()
        {
            return View();
        }
        
        public ActionResult Pay()
        { 
            return View();
        }
    }
}