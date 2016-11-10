using AluPlast.ControlLoader.DAL;
using AluPlast.ControlLoader.Interfaces;
using AluPlast.ControlLoader.MockServices;
using AluPlast.ControlLoader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AluPlast.ControlLoader.Service.Controllers
{
    public class PhotosController : ApiController
    {

        private readonly IPhotosService _PhotosService;

        public PhotosController()
            : this(new DbPhotosService())
        {
        }

        public PhotosController(IPhotosService photosService)
        {
            this._PhotosService = photosService;
        }


        [Route("api/loads/{loadId:int}/photos")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(int loadId)
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                var buffer = await file.ReadAsByteArrayAsync();

                var photo = new Photo { Content = buffer };

                await _PhotosService.AddAsync(photo);

            }

            return Ok();

        }

        [Route("api/loads/{loadId:int}/photos")]
        public async Task<IHttpActionResult> Get(int loadId)
        {
            var photos = await _PhotosService.GetAsync(loadId);

            return Ok(photos);
        }

        [Route("api/loads/{loadId:int}/photos/{id}")]
        public async Task<IHttpActionResult> Get(int loadId, int id)
        {
            var photo = await _PhotosService.GetSingleAsync(id);

            var stream = new MemoryStream(photo.Content);

            return new StreamActionResult(stream);

        }

    }
}