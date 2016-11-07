using AluPlast.ControlLoader.Interfaces;
using AluPlast.ControlLoader.MockServices;
using AluPlast.ControlLoader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.ControlLoader.UWPClient.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public IList<User> Users { get; set; }

        public User SelectedUser { get; set; }

        public string Password { get; set; }

        private readonly IUsersService _UsersService;

        public LoginViewModel()
            : this(new MockUsersService())
        {

        }

        public LoginViewModel(IUsersService usersService)
        {
            _UsersService = usersService;

            Users = _UsersService.Get();
        }




    }
}
