using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Services;
using ReactiveUI;

namespace MusicPlayer.ViewModels
{
    public class PlayerViewModel : ViewModelBase
    {
        IMusicPlayer _musicPlayerService;

        public ReactiveCommand<Unit, Unit> playCommand { get; }
        public ReactiveCommand<Unit, Unit> pauseCommand { get; }
        public PlayerViewModel(IMusicPlayer musicPlayer)
        {
            _musicPlayerService = musicPlayer;
            playCommand = ReactiveCommand.Create(() => {_musicPlayerService.Play(null); });
            pauseCommand = ReactiveCommand.Create(() => {_musicPlayerService.Pause(); });
        }

        public void Play(string path)
        {
            _musicPlayerService.Play(path);
        }

        public void Play()
        {
            _musicPlayerService.Play(null);
        }

        public void Pause()
        {
            _musicPlayerService.Pause();
        }
    }
}
