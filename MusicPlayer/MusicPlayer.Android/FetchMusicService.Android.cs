//using AndroidGlobal = global::Android;
using Android;
using MusicPlayer.Models;
using MusicPlayer.Services;
using MusicPlayer.ViewModels;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using XamarinAndroid = Xamarin.Android;
using Xamarin.Essentials;
using System.Linq;
using System;
using DynamicData;
using Android.Content;
using Plugin.CurrentActivity;
using Android.Provider;

namespace MusicPlayer.Android
{
    public class FetchMusicService : IFetchMusicService
    {
        /*private List<string> GetAllMountedStorages()
        {
            var procMounts = File.ReadAllText("/proc/mounts");
            string sdCardEntry = string.Empty;
            if (!string.IsNullOrWhiteSpace(procMounts))
            {
                var candidateProcMountEntries = procMounts.Split('\n', '\r').ToList();
                candidateProcMountEntries.RemoveAll(s => s.IndexOf("storage", StringComparison.OrdinalIgnoreCase) < 0); //leave only stuff mounted in storage
                candidateProcMountEntries.RemoveAll(s => s.IndexOf("user_id=0,group_id=0", StringComparison.OrdinalIgnoreCase) < 0); // remove stuff we don't have access to
                candidateProcMountEntries.RemoveAll(s => s.IndexOf("emulated", StringComparison.OrdinalIgnoreCase) > 0); //Remove all emulated stuff
                if (candidateProcMountEntries.Any())
                {
                    for (int i = 0; i < candidateProcMountEntries.Count(); i++)
                    {
                        var sdCardEntries = candidateProcMountEntries[i].Split(' ');
                        candidateProcMountEntries[i] = sdCardEntries.FirstOrDefault(s => s.IndexOf("/storage/", StringComparison.OrdinalIgnoreCase) >= 0);
                    }
                    candidateProcMountEntries.Add(AndroidGlobal.OS.Environment.ExternalStorageDirectory.ToString());
                    return candidateProcMountEntries;
                }
                else
                {
                    return new List<string>();
                }
            }
            else
            {
                return new List<string>();
            }
        }
        List<string> RecursiveSafeFolderSearch(string path)
        {
            List<string> list;
            if (!global::Android.OS.Environment.IsExternalStorageManager)
            {
                Intent intent = new Intent(
                global::Android.Provider.Settings.ActionManageAppAllFilesAccessPermission,
                global::Android.Net.Uri.Parse("package:" + global::Android.App.Application.Context.PackageName));

                intent.AddFlags(ActivityFlags.NewTask);

                global::Android.App.Application.Context.StartActivity(intent);
            }
            try
            {
                list = Directory.GetFiles(path).ToList();
                System.Console.WriteLine(list);
                foreach (var dir in Directory.GetDirectories(path))
                {
                    list.AddRange(RecursiveSafeFolderSearch(dir));
                }
                return list;
            }
            catch (UnauthorizedAccessException ex)
            {
                //okay, we can't go there. Can't read this place
            }
            return new List<string>();
        }*/

        public IEnumerable<MusicItemViewModel> GetMusicItems()
        {
            //MediaStore.Audio.Media.InterfaceConsts.Id;
            var collection = new ObservableCollection<MusicItemViewModel>();
            /*List<string> FilesAndDirs = new List<string>();
            //FilesAndDirs.AddRange(Directory.EnumerateFileSystemEntries(AndroidGlobal.OS.Environment.ExternalStorageDirectory.ToString()));
            FilesAndDirs.AddRange(GetAllMountedStorages());
            foreach (var filepath in FilesAndDirs)
            {
                //var files = Directory.GetFiles(filepath, "*.mp3",SearchOption.AllDirectories);
                var files = RecursiveSafeFolderSearch(filepath);
                foreach (string file in files)
                {
                    collection.Add(new MusicItemViewModel
                    {
                        Title = file
                    });
                }
            }*/
            using (ContentResolver resolver = CrossCurrentActivity.Current.AppContext.ContentResolver)
            {
                global::Android.Net.Uri? uri = MediaStore.Audio.Media.ExternalContentUri;
                String selection = MediaStore.Audio.Media.InterfaceConsts.IsMusic + " != 0";
                
                String[] projection = {
    MediaStore.Audio.Media.InterfaceConsts.Id,
    MediaStore.Audio.Media.InterfaceConsts.Artist,
    MediaStore.Audio.Media.InterfaceConsts.Title,
    MediaStore.Audio.Media.InterfaceConsts.Data,
    MediaStore.Audio.Media.InterfaceConsts.DisplayName,
    MediaStore.Audio.Media.InterfaceConsts.Duration
};
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
