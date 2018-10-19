using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TuiFlight.View.ViewModel
{
    public class TravelViewModel
    {
        [Display(Name = "A/R")]
        public bool OneWay { get; set; }
    }
}
