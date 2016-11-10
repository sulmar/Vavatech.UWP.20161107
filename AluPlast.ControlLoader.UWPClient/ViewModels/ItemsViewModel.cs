using AluPlast.ControlLoader.Interfaces;
using AluPlast.ControlLoader.MockServices;
using AluPlast.ControlLoader.Models;
using AluPlast.ControlLoader.UWPClient.RestApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AluPlast.ControlLoader.UWPClient.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public Load SelectedLoad { get; set; }

        private IItemsService _ItemsService;

        

        public ItemsViewModel(IItemsService itemsService)
        {
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


        public ItemsViewModel() : this(new RestApiItemsService())
        {

        }

        public async Task LoadAsync()
        {
        }


        public void Accept()
        {

        }


        public async Task Add()
        {

            var item = new Item { Number = "ABC0001", ItemType = ItemType.EUR };

            try
            {
                await _ItemsService.AddAsync(SelectedLoad.LoadId, item);

                SelectedLoad.Items.Add(item);

            }
            catch(Exception e)
            {
                var dialog = new MessageDialog(e.Message);
                await dialog.ShowAsync();
            }

        }

        public void Back()
        {
            Frame rootFrame = Window.Current.Content as Frame;

            rootFrame.GoBack();
        }
    }
}
