using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.ControlLoader.UWPClient.RestApiServices
{
    public abstract class BaseRestApiService
    {
        public async Task<TItem> GetAsync<TItem>(string request)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(request);

                var items = await response.Content.ReadAsAsync<TItem>();

                return items;
            }
        }
    }
}
