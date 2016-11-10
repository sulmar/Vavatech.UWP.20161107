using AluPlast.ControlLoader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.ControlLoader.Interfaces
{
    public interface ILoadsService
    {
        IList<Load> Get();

        Task<IList<Load>> GetAsync();

        IList<Load> Get(DateTime date);

        Task<IList<Load>> GetAsync(DateTime date);

        void Confirm(int loadId, User @operator);

        void Canceled(int loadId, User @operator);

        Task UpdateAsync(Load load);
    }
}
