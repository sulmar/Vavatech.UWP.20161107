using AluPlast.ControlLoader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluPlast.ControlLoader.Models;

namespace AluPlast.ControlLoader.MockServices
{
    public class MockAuthenticationService : IAuthenticationService
    {
        public bool IsValid(User user, string password)
        {
            return user.Password == password;
        }
    }
}
