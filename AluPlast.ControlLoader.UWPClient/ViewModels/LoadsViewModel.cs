﻿using AluPlast.ControlLoader.Interfaces;
using AluPlast.ControlLoader.MockServices;
using AluPlast.ControlLoader.Models;
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

        public Load SelectedLoad { get; set; }

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

        #endregion

        public LoadsViewModel(ILoadsService loadsService)
        {
            this._LoadsService = loadsService;

            if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            }
        }

        private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            Back();
        }

        public LoadsViewModel()
            : this(new MockLoadsService())
        {
        }

        public async Task LoadAsync()
        {
            IsBusy = true;

            Loads = await _LoadsService.GetAsync(SelectedDate);

            IsBusy = false;
        }

        public void ShowDetails()
        {

        }

        public void Back()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.GoBack();
        }    

    }
}
