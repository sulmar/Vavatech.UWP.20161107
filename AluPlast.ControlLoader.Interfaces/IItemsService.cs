using AluPlast.ControlLoader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.ControlLoader.Interfaces
{
    public interface IItemsService
    {
        Task<IList<Item>> GetAsync(int loadId);

        IList<Item> Get(int loadId);

        void Update(Item item);

        Task AddAsync(int loadId, Item item);
    }
}
