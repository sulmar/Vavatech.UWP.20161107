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
    public class DbLoadsService : ILoadsService
    {
        public void Canceled(int loadId, User @operator)
        {
            throw new NotImplementedException();
        }

        public void Confirm(int loadId, User @operator)
        {
            using (var context = new AluPlastContext())
            {
                var foundLoad = context.Loads.Find(loadId);

                foundLoad.Operator = @operator;
                foundLoad.LoadStatus = LoadStatus.Done;

                context.SaveChanges();

            }
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
            using (var context = new AluPlastContext())
            {
                var loads = await context.Loads
                    .Where(p => p.LoadDate == date)
                    .ToListAsync();

                return loads;
            }
        }

        public async Task UpdateAsync(Load load)
        {
            using(var context = new AluPlastContext())
            {
                var foundLoad = await context.Loads.FindAsync(load.LoadId);

                foundLoad = load;

                await context.SaveChangesAsync();

            }
        }
    }
}
