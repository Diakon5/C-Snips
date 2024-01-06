using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.ViewModels
{
    public class MusicItemViewModel : ViewModelBase
    {
        private MusicItemModel _model;
        public MusicItemViewModel(MusicItemModel model)
        {
            _model = model;
        }
        public MusicItemViewModel(string title, string description, string imagePath, string localPath)
        {
            _model = new MusicItemModel { Title = title, Description = description, ImagePath = imagePath, LocalPath = localPath };
        }
        public MusicItemViewModel()
        {
            _model = new();
        }
        public string Title 
        {
            get {  return _model.Title; }
            set { _model.Title = value; }      
        }
        public string Description
        {
            get { return _model.Description; }
            set { _model.Description = value; }
        }
        public string ImagePath
        {
            get { return _model.ImagePath; }
            set { _model.ImagePath = value; }
        }
        public string LocalPath
        {
            get { return _model.LocalPath; }
            set { _model.LocalPath = value; }
        }

    }

}
