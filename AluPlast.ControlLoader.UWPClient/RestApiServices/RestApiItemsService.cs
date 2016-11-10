using AluPlast.ControlLoader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluPlast.ControlLoader.Models;
using System.Net.Http;

namespace AluPlast.ControlLoader.UWPClient.RestApiServices
{
    public class RestApiItemsService : BaseRestApiService, IItemsService
    {
        public async Task AddAsync(int loadId, Item item)
        {
            var request = $"http://localhost:58892/api/Loads/{loadId}/Items";

            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync<Item>(request, item);

                if (response.IsSuccessStatusCode)
                {
                    item = await response.Content.ReadAsAsync<Item>();
                }
            }
        }

        public IList<Item> Get(int loadId)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Item>> GetAsync(int loadId)
        {
            var request = $"http://localhost:58892/api/Loads/{loadId}/Items";

            return await GetAsync<IList<Item>>(request);

            //using (var client = new HttpClient())
            //{
            //    var request = $"http://localhost:58892/api/Loads/{loadId}/Items";

            //    var response = await client.GetAsync(request);

            //    var items = await response.Content.ReadAsAsync<IList<Item>>();

            //    return items;
            //}
        }

        public void Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
