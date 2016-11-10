using AluPlast.ControlLoader.Interfaces;
using AluPlast.ControlLoader.Models;
using AluPlast.ControlLoader.UWPClient.RestApiServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.ControlLoader.UWPClient.ViewModels
{
    public class PhotosViewModel : BaseViewModel
    {
        public ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();

        private IPhotosService _PhotosService;

        public PhotosViewModel(IPhotosService photosService)
        {
            _PhotosService = photosService;
        }

        public PhotosViewModel()
            : this(new RestApiPhotosService())
        {
        }


        public async Task LoadAsync()
        {
            var photo = await _PhotosService.GetSingleAsync(1);

            Photos.Add(photo);
        }



    }
}
