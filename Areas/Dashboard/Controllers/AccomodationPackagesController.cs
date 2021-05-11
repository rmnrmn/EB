using EB.Areas.Dashboard.ViewModels;
using EB.Areas.Dashboard.Controllers;
using EB.Entities;
using EB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EB.ViewModels;

namespace EB.Areas.Dashboard.Controllers
{
    public class AccomodationPackagesController : Controller
    {
        AccomodationTypesService accomodationTypesService = new AccomodationTypesService();
        AccomodationPackagesService accomodationPackagesService = new AccomodationPackagesService();
        // GET: Dashboard/accomodationPackages
        public ActionResult Index(string searchTerm, int? AccomodationTypeID, int ? page)
        {
            int recordSize = 3;
            page = page ?? 1;
            AccomodationPackageListingModel model = new AccomodationPackageListingModel();

            model.SearchTerm = searchTerm;
            model.AccomodationTypeID = AccomodationTypeID;

            model.AccomodationPackages = accomodationPackagesService.SearchAccomodationPackages(searchTerm, AccomodationTypeID, page.Value, recordSize);

            model.AccomodationTypes = accomodationTypesService.GetAllAccomodationTypes();

            var totalRecords = accomodationPackagesService.SearchAccomodationPackagesCount(searchTerm, AccomodationTypeID);
            //model.Pager = new Pager(totalRecords, page, recordSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationPackageActionModel model = new AccomodationPackageActionModel();

            if (ID.HasValue)//edit a record
            {
                var accomodationPackage = accomodationPackagesService.GetAccomodationPackageByID(ID.Value);

                model.ID = accomodationPackage.ID;
                model.AccomodationTypeID = accomodationPackage.AccomodationTypeID;
                model.Name = accomodationPackage.Name;
                model.NoOfRooms= accomodationPackage.NoOfRooms;
                model.FeePerNight = accomodationPackage.FeePerNight;
            }
            model.AccomodationTypes = accomodationTypesService.GetAllAccomodationTypes();
            return PartialView("_Action", model);

        }
        [HttpPost]
        public ActionResult Action(AccomodationPackageActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            if (model.ID > 0)
            {
                var accomodationPackage = accomodationPackagesService.GetAccomodationPackageByID(model.ID);

                accomodationPackage.AccomodationTypeID = model.AccomodationTypeID;
                accomodationPackage.Name = model.Name;
                accomodationPackage.NoOfRooms = model.NoOfRooms;
                accomodationPackage.FeePerNight = model.FeePerNight;

                result = accomodationPackagesService.UpdateAccomodationPackage(accomodationPackage);
            }
            else
            {
                AccomodationPackage accomodationPackage = new AccomodationPackage();

                accomodationPackage.AccomodationTypeID = model.AccomodationTypeID;
                accomodationPackage.Name = model.Name;
                accomodationPackage.Name = model.Name;
                accomodationPackage.NoOfRooms = model.NoOfRooms;

                result = accomodationPackagesService.SaveAccomodationPackage(accomodationPackage);
            }



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
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccomodationPackageActionModel model = new AccomodationPackageActionModel();

            var accomodationPackage = accomodationPackagesService.GetAccomodationPackageByID(ID);

            model.ID = accomodationPackage.ID;

            return PartialView("_Delete", model);

        }
        [HttpPost]
        public ActionResult Delete(AccomodationPackageActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var accomodationPackage = accomodationPackagesService.GetAccomodationPackageByID(model.ID);

            result = accomodationPackagesService.DeleteAccomodationPackage(accomodationPackage);

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