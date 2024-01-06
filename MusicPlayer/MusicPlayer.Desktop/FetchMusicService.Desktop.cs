using MusicPlayer.ViewModels;
using MusicPlayer.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace MusicPlayer.Desktop
{
    public class FetchMusicService : IFetchMusicService
    {
        private List<string> fileList;
        public FetchMusicService() 
        {
            fileList = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)).ToList<string>();

            
            Debug.WriteLine(fileList.RemoveAll(x => Path.GetExtension(x) != ".mp3" && Path.GetExtension(x) != ".ogg"));
        }

        public IEnumerable<MusicItemViewModel> GetMusicItems()
        {
            var collection = new ObservableCollection<MusicItemViewModel>();
            foreach (var item in fileList)
            {
                collection.Add(new MusicItemViewModel
                {
                    Title = Path.GetFileNameWithoutExtension(item),
                    LocalPath = item
                }
                );
            }
            return collection;
            /*
            return new ObservableCollection<MusicItemViewModel> { 
                new MusicItemViewModel {Title = "Dummy Desktop 1"},
                new MusicItemViewModel {Title = "Dummy Desktop 2"},
            };
            */
        }
    }
}
