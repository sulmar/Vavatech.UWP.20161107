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
    public class RestApiLoadsService : BaseRestApiService, ILoadsService
    {
        public void Canceled(int loadId, User @operator)
        {
            throw new NotImplementedException();
        }

        public void Confirm(int loadId, User @operator)
        {
            throw new NotImplementedException();
        }

        public IList<Load> Get()
        {
            throw new NotImplementedException();
        }

        public IList<Load> Get(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Load>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Load>> GetAsync(DateTime date)
        {
            // TODO: przenieść adres do konfiguracji

            var request = $"http://localhost:58892/api/Loads/{date:yyyy-MM-dd}";

            return await GetAsync<IList<Load>>(request);

            //using (var client = new HttpClient())
            //{
            //    var request = $"http://localhost:58892/api/Loads/{date:yyyy-MM-dd}";

            //    var response = await client.GetAsync(request);

            //    var loads = await response.Content.ReadAsAsync<IList<Load>>();

            //    return loads;
            //}
        }

        public async Task UpdateAsync(Load load)
        {
            var request = $"http://localhost:58892/api/Loads/{load.LoadId}";

            using (var client = new HttpClient())
            {
                var response = await client.PutAsJsonAsync<Load>(request, load);

                if (!response.IsSuccessStatusCode)
                {

                }
            }
        }
    }
}
