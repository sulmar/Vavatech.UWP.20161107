using AluPlast.ControlLoader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluPlast.ControlLoader.Models;

namespace AluPlast.ControlLoader.DAL
{
    public class DbPhotosService : IPhotosService
    {
        public void Add(Photo photo)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Photo photo)
        {
            using (var context = new AluPlastContext())
            {
                context.Photos.Add(photo);

                await context.SaveChangesAsync();
            }
        }

        public IList<Photo> Get(int loadId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int photoId)
        {
            throw new NotImplementedException();
        }
    }
}
