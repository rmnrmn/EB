using EB.Entities;
using EB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EB.Areas.Dashboard.ViewModels
{
    public class AccomodationPackageListingModel

    {
            public IEnumerable<AccomodationPackage> AccomodationPackages { get; set; }
            public int? AccomodationTypeID { get; set; }
            public IEnumerable<AccomodationType> AccomodationTypes { get; set; }
            public string SearchTerm { get; set; }

            public Pager Pager { get; set; }
    }
        public class AccomodationPackageActionModel

        {
            public int ID { get; set; }
            public int AccomodationTypeID { get; set; }
            public AccomodationType AccomodationType { get; set; }
            public string Name { get; set; }
            public int NoOfRooms { get; set; }
            public decimal FeePerNight { get; set; }
            public IEnumerable<AccomodationType> AccomodationTypes { get; set; }
        }
    }