using AluPlast.ControlLoader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluPlast.ControlLoader.Models;
using System.IO;

namespace AluPlast.ControlLoader.MockServices
{
    public class MockPhotosService : IPhotosService
    {
        private IList<Photo> _Photos = new List<Photo>
        {
            new Photo { PhotoId = 1 },
            new Photo { PhotoId = 2 },
            new Photo { PhotoId = 3 },
        };

        public void Add(Photo photo)
        {
            _Photos.Add(photo);
        }

        public IList<Photo> Get(int loadId)
        {
            return _Photos;
        }

        public void Remove(int photoId)
        {
            throw new NotImplementedException();
        }

        private byte[] Load(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
