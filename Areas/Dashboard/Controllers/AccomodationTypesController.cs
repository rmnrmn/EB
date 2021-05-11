using EB.Areas.Dashboard.ViewModels;
using EB.Entities;
using EB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EB.Areas.Dashboard.Controllers
{
    public class AccomodationTypesController : Controller
    {
        AccomodationTypesService accomodationTypesService = new AccomodationTypesService();
        // GET: Dashboard/AccomodationTypes
        public ActionResult Index(string searchTerm)
        {
            AccomodationTypesListingModel model = new AccomodationTypesListingModel();

            model.SearchTerm = searchTerm;

            model.AccomodationTypes = accomodationTypesService.SearchAccomodationTypes(searchTerm);

            return View(model);
        }
        
        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationTypesActionModel model = new AccomodationTypesActionModel();

            if(ID.HasValue)//edit a record
            {
                var accomodationType = accomodationTypesService.GetAccomodationTypeByID(ID.Value);
                model.ID = accomodationType.ID;
                model.Name = accomodationType.Name;
                model.Description = accomodationType.Description;
            }
         
            return PartialView("_Action", model);

        }
        [HttpPost] 
        public ActionResult Action(AccomodationTypesActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            if(model.ID > 0)
            {
                var accomodationType = accomodationTypesService.GetAccomodationTypeByID(model.ID);
                
                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;

                result = accomodationTypesService.UpdateAccomodationType(accomodationType);

            }
            else
            {
                AccomodationType accomodationType = new AccomodationType();

                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;

                result = accomodationTypesService.SaveAccomodationType(accomodationType);
            }

           

            if(result)
            {
                json.Data = new { Succes = true };
            }
            else
            {
                json.Data = new { Succes = false, MEssage = "Unable to performe action on Accomodation Types." };
            }
            return json;
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccomodationTypesActionModel model = new AccomodationTypesActionModel();
            
            var accomodationType = accomodationTypesService.GetAccomodationTypeByID(ID);
            
            model.ID = accomodationType.ID;
                
            return PartialView("_Delete", model);

        }
        [HttpPost]
        public ActionResult Delete(AccomodationTypesActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var accomodationType = accomodationTypesService.GetAccomodationTypeByID(model.ID);

            result = accomodationTypesService.DeleteAccomodationType(accomodationType);

            if (result)
            {
                json.Data = new { Succes = true };
            }
            else
            {
                json.Data = new { Succes = false, MEssage = "Unable to performe action on Accomodation Types." };
            }
            return json;
        }
    }
}