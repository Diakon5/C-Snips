using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class MusicItemModel
    {
        public string ImagePath { get; set; } = string.Empty;
        public string Title { get; set; } = "Title";
        public string Description { get; set; } = "Description";
        public string LocalPath { get; set; } = string.Empty;


    }
}
