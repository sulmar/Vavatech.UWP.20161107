using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.ControlLoader.Models
{
    public class Item : Base
    {
        public int ItemId { get; set; }

        public string Number { get; set; }

        public ItemType ItemType { get; set; }

        private bool? _IsLoaded;
        public bool? IsLoaded
        {
            get
            {
                return _IsLoaded;
            }

            set
            {
                _IsLoaded = value;
                OnPropertyChanged();
            }
        }

        public string FullName => $"{ItemType} {Number}";
    }
}
