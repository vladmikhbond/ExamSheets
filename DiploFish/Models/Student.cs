using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiploFish.Models
{
    public class Student
    {
        public string Name { get; set; }  // @[name]
        public string NameG { get; set; } // @[name'] 
        public string Group { get; set; } // @[group]
        public string Theme { get; set; } // @[theme]
        public string Plagiat { get; set; } // @[plagiat]
        public string Date { get; set; }    // @[date]
        public string Resume { get; set; }  // @[resume]

        // for Review only
        public string Mark { get; set; }   // @[mark]
        public int Pages { get; set; }     // @[pages]
        public int Slides { get; set; }    // @[slides]
    }
}
 