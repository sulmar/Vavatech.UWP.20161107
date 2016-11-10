using AluPlast.ControlLoader.Interfaces;
using AluPlast.ControlLoader.MockServices;
using AluPlast.ControlLoader.Models;
using AluPlast.ControlLoader.UWPClient.RestApiServices;
using AluPlast.ControlLoader.UWPClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AluPlast.ControlLoader.UWPClient.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public Load SelectedLoad { get; set; }

        private IItemsService _ItemsService;
        private ILoadsService _LoadsService;
        private IPhotosService _PhotosService;

        

        public ItemsViewModel(
            IItemsService itemsService, 
            ILoadsService loadsService,
            IPhotosService photosService)
        {
            this._ItemsService = itemsService;
            this._LoadsService = loadsService;
            this._PhotosService = photosService;

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


        public ItemsViewModel() : this(new RestApiItemsService(), new RestApiLoadsService(), new RestApiPhotosService())
        {

        }

        public async Task LoadAsync()
        {
        }


        public async Task Accept()
        {
            SelectedLoad.LoadStatus = LoadStatus.Done;

            await _LoadsService.UpdateAsync(SelectedLoad);
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

        public void ShowPictures()
        {
            Frame rootFrame = Window.Current.Content as Frame;

            rootFrame.Navigate(typeof(PhotosView), SelectedLoad);
        }

        public async Task TakePicture()
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;

            // captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

            StorageFile photoFile = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);


            if (photoFile != null)
            {
                IRandomAccessStreamWithContentType stream = await photoFile.OpenReadAsync();

                var buffer = new byte[stream.Size];

                await stream.ReadAsync(buffer.AsBuffer(), (uint) stream.Size, InputStreamOptions.None);

                var photo = new Photo { Content = buffer, Description = "My photo" };

                await _PhotosService.AddAsync(photo);
            }

        }
        public void Back()
        {
            Frame rootFrame = Window.Current.Content as Frame;

            rootFrame.GoBack();
        }
    }
}
