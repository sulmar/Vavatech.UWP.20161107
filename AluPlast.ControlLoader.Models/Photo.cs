﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.ControlLoader.Models
{
    public class Photo : Base
    {
        public int PhotoId { get; set; }

        public byte[] Content { get; set; }


        public string Description { get; set; }
    }
}
