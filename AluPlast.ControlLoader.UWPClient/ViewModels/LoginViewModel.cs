using AluPlast.ControlLoader.Interfaces;
using AluPlast.ControlLoader.MockServices;
using AluPlast.ControlLoader.Models;
using AluPlast.ControlLoader.UWPClient.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AluPlast.ControlLoader.UWPClient.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public IList<User> Users { get; set; }

        #region SelectedUser

        private User _SelectedUser;
        public User SelectedUser
        {
            get { return _SelectedUser; }
            set
            {
                _SelectedUser = value;

                OnPropertyChanged();

                LoginCommand.OnCanExecuteChanged();
            }
        }

        #endregion


        #region Password

        private string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;

                OnPropertyChanged();

                LoginCommand.OnCanExecuteChanged();
            }
        }

        #endregion

        #region Services

        private readonly IUsersService _UsersService;
        private readonly IAuthenticationService _AuthenticationService;

        #endregion

        public LoginViewModel()
            : this(new MockUsersService(), new MockAuthenticationService())
        {

        }

        public LoginViewModel(IUsersService usersService, IAuthenticationService authenticationService)
        {
            _UsersService = usersService;
            _AuthenticationService = authenticationService;

            Users = _UsersService.Get();
        }



        #region LoginCommand

        private RelayCommand _LoginCommand;

        public RelayCommand LoginCommand
        {
            get
            {
                if (_LoginCommand == null)
                    _LoginCommand = new RelayCommand(Login, CanLogin);

                return _LoginCommand;
            }
        }

        private void Login()
        {
            if (_AuthenticationService.IsValid(this.SelectedUser, this.Password))
            {
            }
            else
            {
                

            }
        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Password) && SelectedUser != null;
        }

        #endregion

    }
}
