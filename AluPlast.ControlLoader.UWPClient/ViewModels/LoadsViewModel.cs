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
    public class LoadsViewModel : BaseViewModel
    {
        #region Properties

        public IList<Load> Loads { get; set; }

        public Load SelectedLoad { get; set; }

        public DateTime SelectedDate { get; set; } = DateTime.Today;

        #endregion

        #region Services

        private ILoadsService _LoadsService;

        #endregion

        public LoadsViewModel(ILoadsService loadsService)
        {
            this._LoadsService = loadsService;

            Loads = _LoadsService.Get(SelectedDate);
        }

        public LoadsViewModel()
            : this(new MockLoadsService())
        {
        }

        public void ShowDetails()
        {

        }

    }
}
