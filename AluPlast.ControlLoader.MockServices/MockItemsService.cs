using AluPlast.ControlLoader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluPlast.ControlLoader.Models;

namespace AluPlast.ControlLoader.MockServices
{
    public class MockItemsService : IItemsService
    {
        private IList<Item> _Items = new List<Item>
        {
            new Item { ItemId = 1, Number = "4011", ItemType = ItemType.EUR, IsLoaded = false },
            new Item { ItemId = 2, Number = "4012", ItemType = ItemType.PAL, IsLoaded = false },
            new Item { ItemId = 3, Number = "4013", ItemType = ItemType.SZY, IsLoaded = true },
            new Item { ItemId = 4, Number = "4014", ItemType = ItemType.EUR, IsLoaded = false },
        };


        public IList<Item> Get(int loadId)
        {
            return _Items;
        }

        public Task<IList<Item>> GetAsync(int loadId)
        {
            return Task.Run(() => Get(loadId));
        }

        public void Update(Item item)
        {
            item.IsLoaded = true;
        }
    }
}
