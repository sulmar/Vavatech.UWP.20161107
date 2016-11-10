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

        Task<IList<Photo>> GetAsync(int loadId);

        Task<Photo> GetSingleAsync(int photoId);

        void Add(Photo photo);

        Task AddAsync(Photo photo);

        void Remove(int photoId);
    }
}
