using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<Item> _Items = new ObservableCollection<Item>();

        public ObservableCollection<Item> Items
        {
            get
            {
                return _Items;
            }

            set
            {
                OnItemsChanging();

                _Items = value;

                OnItemsChanged();

                OnPropertyChanged();
                OnPropertyChanged(nameof(Progress));
                OnPropertyChanged(nameof(LoadedItemsCount));
                OnPropertyChanged(nameof(NotCanceledCount));


            }
        }

        private void OnItemsChanging()
        {
            foreach (var item in this.Items)
            {
                item.PropertyChanged -= Item_PropertyChanged;
            }
        }
        private void OnItemsChanged()
        {
            foreach (var item in this.Items)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }
        }

        public IList<Photo> Photos { get; set; }

        public LoadStatus LoadStatus { get; set; }

        public int LoadedItemsCount => Items.Count(p => p.IsLoaded.HasValue && p.IsLoaded.Value);

        public int NotCanceledCount => Items.Count(p => p.IsLoaded.HasValue);

        public double Progress =>  NotCanceledCount == 0 ? 0 : (double) decimal.Divide(LoadedItemsCount, NotCanceledCount);

        public bool CanAccept => Items.All(p => p.IsLoaded.HasValue && p.IsLoaded.Value);

        public Load()
        {
           
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Item.IsLoaded))
            {
                OnPropertyChanged(nameof(CanAccept));
            }
        }
    }
}
