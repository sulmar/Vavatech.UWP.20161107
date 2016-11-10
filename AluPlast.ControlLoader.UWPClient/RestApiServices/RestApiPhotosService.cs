using AluPlast.ControlLoader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluPlast.ControlLoader.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AluPlast.ControlLoader.UWPClient.RestApiServices
{
    public class RestApiPhotosService : BaseRestApiService, IPhotosService
    {
        public void Add(Photo photo)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Photo photo)
        {

            var request = "http://localhost:58892/api/Loads/1/Photos";

            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    var fileContent = new ByteArrayContent(photo.Content);
                    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = photo.Description
                    };
                    content.Add(fileContent, "file");

                    var response = await client.PostAsync(request, content);
                }
            }
        }

        public IList<Photo> Get(int loadId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int photoId)
        {
            throw new NotImplementedException();
        }
    }
}
