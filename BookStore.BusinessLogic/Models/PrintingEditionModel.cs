using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BookStore.BusinessLogic.Models
{
    public class PrintingEditionModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }

        public string Currency { get; set; }

        public string Type { get; set; }

        public int Id { get; set; }

        public List<AuthorModel> Authors { get; set; }

        public PrintingEditionModel() { }

        internal PrintingEditionModel(PrintingEdition printingEdition)
        {
            Name = printingEdition.Name;

            Type = printingEdition.Type;

            Price = printingEdition.Price;

            Currency = printingEdition.Currency;

            Status = printingEdition.Status;

            Description = printingEdition.Description;

            Id = printingEdition.Id;
        }

        public PrintingEdition PrintingEditionMapToEntity()
        {
            PrintingEdition printingEdition = new PrintingEdition();

            printingEdition.Name = this.Name;

            printingEdition.Type = this.Type;

            printingEdition.Price = this.Price;

            printingEdition.Status = this.Status;

            printingEdition.Currency = this.Currency;

            printingEdition.Description = this.Description;

            

            return printingEdition;
        }

    }
}
