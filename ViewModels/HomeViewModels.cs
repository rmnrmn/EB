using EB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EB.ViewModels
{
    public class HomeViewModels
    {
        public IEnumerable<AccomodationType> AccomodationTypes  { get; set; }
    }
}