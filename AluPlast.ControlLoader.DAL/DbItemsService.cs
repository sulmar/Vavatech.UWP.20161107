using AluPlast.ControlLoader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluPlast.ControlLoader.Models;

namespace AluPlast.ControlLoader.DAL
{
    public class DbItemsService : IItemsService
    {
        public async Task AddAsync(int loadId, Item item)
        {
            using(var context = new AluPlastContext())
            {
                context.Items.Add(item);

                await context.SaveChangesAsync();
            }
        }

        public IList<Item> Get(int loadId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Item>> GetAsync(int loadId)
        {
            throw new NotImplementedException();
        }

        public void Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
