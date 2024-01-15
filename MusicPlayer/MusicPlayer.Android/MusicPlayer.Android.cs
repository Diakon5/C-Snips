using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Media;
using MusicPlayer.Services;

namespace MusicPlayer.Android
{
    internal class MusicPlayer : IMusicPlayer
    {
        protected MediaPlayer player;
        public MusicPlayer() 
        { 
            player = new MediaPlayer();
        }

        public bool IsPaused()
        {
            return !player.IsPlaying;
        }

        public bool IsPlaying()
        {
            return player.IsPlaying;
        }

        public void Pause()
        {
            player.Pause();
        }

        public void Play(string? songPath)
        {
            if (songPath != null)
            {
                player.SetDataSource(songPath);
            }
            player.Start();
        }

    }
}
