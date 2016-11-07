using AluPlast.ControlLoader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluPlast.ControlLoader.Models;

namespace AluPlast.ControlLoader.MockServices
{
    public class MockPhotosService : IPhotosService
    {
        private IList<Photo> _Photos;

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
    }
}
