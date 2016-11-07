using AluPlast.ControlLoader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluPlast.ControlLoader.Interfaces
{
    public interface ILoadsService
    {
        IList<Load> Get();

        IList<Load> Get(DateTime date);

        void Confirm(int loadId, User @operator);

        void Canceled(int loadId, User @operator);
    }
}
