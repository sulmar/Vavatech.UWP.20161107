using AluPlast.ControlLoader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluPlast.ControlLoader.Models;
using System.Data.Entity;

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

        public async Task<IList<Item>> GetAsync(int loadId)
        {
            using (var context = new AluPlastContext())
            {
                var load = await context.Loads
                    .Include(path=>path.Items)
                    .SingleOrDefaultAsync(p => p.LoadId == loadId);

                return load?.Items;
            }
        }

        public void Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
