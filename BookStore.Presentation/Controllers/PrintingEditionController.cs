using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.BusinessLogic.Services.Intefaces;
using BookStore.BusinessLogic.Models;
using BookStore.BusinessLogic.Services;

namespace BookStore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintingEditionController : ControllerBase
    {
        public PrintingEditionController(PrintingEditionService printingEditionService)
        {
            _printingEditionService = printingEditionService;
        }

        IPrintingEditionService _printingEditionService;

        [HttpPost("Post")]
        [Authorize(Roles ="Admin")]
        public async Task AddPrintingEdition([FromBody]PrintingEditionModel printingEditionModel)
        {
            await _printingEditionService.AddPrintingEdition(printingEditionModel);
        }

        [HttpGet("Get")]
        [Authorize(Roles = "Admin")]
        public async Task<PrintingEditionModel> GetPrintingEdition([FromBody]int id)
        {
            return await _printingEditionService.GetPrintingEditionModel(id);
        }

        [HttpGet("GetAll")]
        public async Task<List<PrintingEditionModel>> GetAllPrintingEdition()
        {
            return await _printingEditionService.GetPrintingEditionModels();
        }
        [HttpPost("Delete")]
        [Authorize(Roles ="Admin")]

        public async Task Delete([FromBody]int id)
        {
            await _printingEditionService.DeletePrintingEditionById(id);
        }
    }
}