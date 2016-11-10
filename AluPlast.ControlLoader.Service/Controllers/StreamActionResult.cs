using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace AluPlast.ControlLoader.Service.Controllers
{
    public class StreamActionResult : IHttpActionResult
    {
        private readonly Stream _content;
        private readonly string _contentType;

        public StreamActionResult(Stream content, string contentType = null)
        {
            if (content == null) throw new ArgumentNullException(nameof(content));

            _content = content;
            _contentType = contentType;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(_content)
            };

            if (_contentType == null)
            {
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            }
            else
            {
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(_contentType);
            }


            return Task.FromResult(response);
        }
    }
}