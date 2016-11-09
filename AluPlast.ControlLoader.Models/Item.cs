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

        public bool? IsLoaded { get; set; }

        public string FullName => $"{ItemType} {Number}";
    }
}
