using Android.App;
using Android.Content;
using Android.Media;
using Android.Provider;
using MusicPlayer.Models;
using MusicPlayer.Services;
using MusicPlayer.ViewModels;
using Plugin.CurrentActivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Android;
using Xamarin.Essentials;

namespace MusicPlayer.Android
{
    public class FetchMusicService : IFetchMusicService
    {
        public IEnumerable<MusicItemViewModel> GetMusicItems()
        {
            //MediaStore.Audio.Media.InterfaceConsts.Id;
            var collection = new ObservableCollection<MusicItemViewModel>();
            using (ContentResolver resolver = CrossCurrentActivity.Current.AppContext.ContentResolver)
            {
                var uri = MediaStore.Audio.Media.ExternalContentUri;
                var cursor = resolver.Query(uri, null, null, null, null);
                if (cursor == null)
                {
                    // query failed, handle error.
                }
                else if (!cursor.MoveToFirst())
                {
                    // no media on the device
                }
                else
                {
                    int titleColumn = cursor.GetColumnIndex(MediaStore.IMediaColumns.Title);
                    int idColumn = cursor.GetColumnIndex(IBaseColumns.Id);
                    int pathColumn = cursor.GetColumnIndex(MediaStore.IMediaColumns.RelativePath);
                    do
                    {
                        long thisId = cursor.GetLong(idColumn);
                        String thisTitle = cursor.GetString(titleColumn);
                        string thisPath = cursor.GetString(pathColumn);
                        collection.Add(new MusicItemViewModel
                        {
                            Title = thisTitle,
                            LocalPath = thisPath
                        });
                    } while (cursor.MoveToNext());
                }
            }

            /*return new ObservableCollection<MusicItemViewModel> {
                new MusicItemViewModel { Title = "Dummy Android 1" },
                new MusicItemViewModel { Title = "Dummy Android 2" }
            };*/
            return collection;
        }
    }
}
