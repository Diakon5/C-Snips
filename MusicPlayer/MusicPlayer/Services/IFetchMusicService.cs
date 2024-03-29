﻿using MusicPlayer.Models;
using MusicPlayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Services
{
    public interface  IFetchMusicService
    {
        public IEnumerable<MusicItemViewModel> GetMusicItems();
        
    }
}
