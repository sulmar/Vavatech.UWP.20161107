using AluPlast.ControlLoader.DAL;
using AluPlast.ControlLoader.Interfaces;
using AluPlast.ControlLoader.MockServices;
using AluPlast.ControlLoader.Models;
using System;
using System.Collections.Generic;
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
    }
}