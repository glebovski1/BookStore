using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models
{
    public class IndexViewModelForPrintingEdition
    {
        public IEnumerable<PrintingEditionModel> PrintingEditionModels { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
