using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models
{
     public class FilterModel
    {
        public string name { get; set; }
        public decimal uperprice { get; set; }

        public decimal lowerprice { get; set; }

        public string type { get; set; }

        public string author { get; set; }

        public int pagenumber { get; set; }
        public FilterModel() { }

    }
}
