using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluPlast.ControlLoader.Models
{
    public class Load : Base
    {
        public int LoadId { get; set; }

        public DateTime LoadDate { get; set; }

        public Vehicle Vehicle { get; set; }

        public User Operator { get; set; }

        private IList<Item> _Items;
        public IList<Item> Items
        {
            get
            {
                return _Items;
            }

            set
            {
                _Items = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Progress));
                OnPropertyChanged(nameof(LoadedItemsCount));
            }
        }

        public IList<Photo> Photos { get; set; }

        public LoadStatus LoadStatus { get; set; }

        public int LoadedItemsCount => Items?.Count(p => p.IsLoaded.HasValue && p.IsLoaded.Value) ?? 0;

        public double Progress =>  (Items?.Count ?? 0)==0 ? 0 : (double) decimal.Divide(LoadedItemsCount, Items.Count);

    }
}
