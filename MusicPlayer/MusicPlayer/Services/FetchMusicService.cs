using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Services
{
    public abstract class FetchMusicService
    {
        abstract public IEnumerable<MusicItem> GetItems();
    }
}
