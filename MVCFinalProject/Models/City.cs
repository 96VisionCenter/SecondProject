using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Models
{
    public class City
    {
        public int id{ get; set; }
        public string Name { get; set; }
        public int Stateid { get; set; }
        public State State { get; set; }

    }
}