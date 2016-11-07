using AluPlast.ControlLoader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluPlast.ControlLoader.Models;

namespace AluPlast.ControlLoader.MockServices
{
    public class MockUsersService : IUsersService
    {
        private IList<User> _Users = new List<User>
        {
            new User { UserId = 1, FirstName = "Marcin", LastName = "Sulecki", Password = "123" },
            new User { UserId = 2, FirstName = "Michał", LastName = "", Password = "321" },
            new User { UserId = 3, FirstName = "Maciej", LastName = "", Password = "231" },
        };

        public IList<User> Get()
        {
            return _Users;
        }
    }
}
