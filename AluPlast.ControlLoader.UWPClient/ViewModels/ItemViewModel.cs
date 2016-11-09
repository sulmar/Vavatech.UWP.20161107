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
    public class ItemViewModel : BaseViewModel
    {
        public Load SelectedLoad { get; set; }

        private IItemsService _ItemsService;

        

        public ItemViewModel(IItemsService itemsService)
        {
            this._ItemsService = itemsService;
        }

        public ItemViewModel() : this(new MockItemsService())
        {

        }

        public async Task LoadAsync()
        {
            SelectedLoad.Items = await _ItemsService.GetAsync(SelectedLoad.LoadId);
        }



    }
}
