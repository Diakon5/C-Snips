using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Services
{
    public interface IMusicPlayer
    {
        public void Play(string? songPath);
        public void Pause();
        public bool IsPlaying();
        public bool IsPaused();
    }
}
