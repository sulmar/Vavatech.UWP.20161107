using AluPlast.ControlLoader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.ControlLoader.Interfaces
{
    public interface IPhotosService
    {
        IList<Photo> Get(int loadId);

        void Add(Photo photo);

        void Remove(int photoId);
    }
}
