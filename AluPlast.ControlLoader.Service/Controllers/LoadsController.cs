using AluPlast.ControlLoader.Interfaces;
using AluPlast.ControlLoader.MockServices;
using AluPlast.ControlLoader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AluPlast.ControlLoader.Service.Controllers
{
    public class LoadsController : ApiController
    {
        private ILoadsService _LoadsService;
        private IItemsService _ItemsService;

        public LoadsController(ILoadsService loadsService, IItemsService itemsService)
        {
            this._LoadsService = loadsService;
            this._ItemsService = itemsService;
        }

        public LoadsController()
            : this(new MockLoadsService(), new MockItemsService())
        {
        }

        [Route("api/loads/{date}")]
        public async Task<IList<Load>> Get(DateTime date)
        {
            return await _LoadsService.GetAsync(date);
        }

        [Route("api/loads/{number}/items")]
        public async Task<IList<Item>> Get(string number)
        {
            throw new NotImplementedException();
        }


        [Route("api/loads/{loadId:int}/items")]
        public async Task<IList<Item>> Get(int loadId)
        {
            return await _ItemsService.GetAsync(loadId);
        }


    
    }


      
}