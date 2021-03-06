﻿using AluPlast.ControlLoader.DAL;
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
            : this(new DbLoadsService(), new DbItemsService())
        {
        }

        [Route("api/loads/{date}")]
        public async Task<IHttpActionResult> Get(DateTime date)
        {
            var loads = await _LoadsService.GetAsync(date);

            if (!loads.Any())
            {
                return NotFound();
            }

            return Ok(loads);
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



        [Route("api/loads/{id:int}/items")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(int id, Item item)
        {
            await _ItemsService.AddAsync(id, item);

            return Created("", item);
        }

        [Route("api/loads/{id:int}")]
        [HttpPut]
        public IHttpActionResult Put(int id, Load load)
        {
            _LoadsService.Confirm(load.LoadId, load.Operator);

            return Ok();
        }


    
    }


      
}