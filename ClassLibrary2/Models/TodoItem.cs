using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLibrary2.Models
{
    public class TodoItem
    {
        public int id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}
