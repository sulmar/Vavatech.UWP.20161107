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

        public IList<Item> Items { get; set; }

        public IList<Photo> Photos { get; set; }

        public LoadStatus LoadStatus { get; set; }

    }
}
