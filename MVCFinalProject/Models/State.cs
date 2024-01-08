using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Models
{
    public class State
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Countryid{ get; set; }
        public Country Country { get; set; }


    }
}