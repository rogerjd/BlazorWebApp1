﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLibrary2.Models
{
    public class Emp
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /*
        public string FName;
        public string LName;
        */

        public string Test { get; set; } = "abc";

        public string FullName { get { return LastName + ", " + FirstName; } }
    }
}
