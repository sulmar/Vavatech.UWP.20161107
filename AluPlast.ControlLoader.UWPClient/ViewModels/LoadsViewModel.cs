using AluPlast.ControlLoader.Interfaces;
using AluPlast.ControlLoader.MockServices;
using AluPlast.ControlLoader.Models;
using AluPlast.ControlLoader.UWPClient.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AluPlast.ControlLoader.UWPClient.ViewModels
{
    public class LoadsViewModel : BaseViewModel
    {
        #region Properties

        #region Loads

        private IList<Load> _Loads;
        public IList<Load> Loads
        {
            get
            {
                return _Loads;
            }

            set
            {
                _Loads = value;

                OnPropertyChanged();
            }
        }

        #endregion

        private Load _SelectedLoad;
        public Load SelectedLoad
        {
            get
            {
                return _SelectedLoad;
            }

            set
            {
                _SelectedLoad = value;
            }
        }

        public DateTime SelectedDate { get; set; } = DateTime.Today;

        #region IsBusy

        private bool _IsBusy;
        public bool IsBusy
        {
            get
            {
                return _IsBusy;
            }

            set
            {
                _IsBusy = value;

                OnPropertyChanged();
            }
        }

        #endregion

        #endregion

        #region Services

        private ILoadsService _LoadsService;
        private IItemsService _ItemsService;

        #endregion

        public LoadsViewModel(ILoadsService loadsService, IItemsService itemsService)
        {
            this._LoadsService = loadsService;
            this._ItemsService = itemsService;

            if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            }
        }

        private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            Back();

            e.Handled = true;
        }

        public LoadsViewModel()
            : this(new MockLoadsService(), new MockItemsService())
        {
        }

        public async Task LoadAsync()
        {
            IsBusy = true;

            Loads = await _LoadsService.GetAsync(SelectedDate);

            IsBusy = false;
        }

        public async Task ShowDetails()
        {
            // SelectedLoad.Items = await _ItemsService.GetAsync(SelectedLoad.LoadId);

            Frame rootFrame = Window.Current.Content as Frame;

            rootFrame.Navigate(typeof(ItemsView), SelectedLoad);
        }


        public void Back()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.GoBack();
        }    

    }
}
