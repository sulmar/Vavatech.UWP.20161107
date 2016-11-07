using AluPlast.ControlLoader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AluPlast.ControlLoader.Models;

namespace AluPlast.ControlLoader.MockServices
{
    public class MockLoadsService : ILoadsService
    {
        private static IList<Load> _Loads = new List<Load>
        {
            new Load
            {
                LoadId = 1,
                LoadDate = DateTime.Parse("2016-11-07"),
                Operator = new User { UserId = 1, FirstName = "Marcin", LastName = "Sulecki" },
                LoadStatus = LoadStatus.Waiting,
                Vehicle = new Vehicle { VehicleId=1, RegistrationNumber = "PZ 013334" },
            },

            new Load
            {
                LoadId = 2,
                LoadDate = DateTime.Parse("2016-11-07"),
                Operator = new User { UserId = 1, FirstName = "Maciej", LastName = "" },
                LoadStatus = LoadStatus.Done,
                Vehicle = new Vehicle { VehicleId=1, RegistrationNumber = "PZ 434565P" },
            },

            new Load
            {
                LoadId = 1,
                LoadDate = DateTime.Parse("2016-11-07"),
                Operator = new User { UserId = 1, FirstName = "Michał", LastName = "" },
                LoadStatus = LoadStatus.InProgress,
                Vehicle = new Vehicle { VehicleId=1, RegistrationNumber = "PZ 0758585" },
            },
        };

        public void Canceled(int loadId, User @operator)
        {
            ChangeStatus(loadId, @operator, LoadStatus.Canceled);
        }

      
        public void Confirm(int loadId, User @operator)
        {
            ChangeStatus(loadId, @operator, LoadStatus.Done);
        }

        private void ChangeStatus(int loadId, User @operator, LoadStatus status)
        {
            var load = _Loads.SingleOrDefault(l => l.LoadId == loadId);

            if (load == null)
                throw new KeyNotFoundException();

            load.Operator = @operator;
            load.LoadStatus = status;
        }

        public IList<Load> Get()
        {
            return _Loads;
        }

        public IList<Load> Get(DateTime date)
        {
            return _Loads
                .Where(l => l.LoadDate == date)
                .ToList();
        }
    }
}
