using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMusic.GlobalUsageClasses
{
    static class MusicCurrentStatus
    {
        private static string? _nowPlaying;
        private static bool _isPlaying;
        public static string? NowPlayingMusic
        {
            get { return _nowPlaying; }
            set
            {
                if (value != NowPlayingMusic)
                {
                    _nowPlaying = value;

                    OnChangedSong(value, new EventArgs());
                }
            }
        }

        public static bool IsPlaying
        {
            get => _isPlaying;
            set
            {
                if (value != IsPlaying)
                {
                    _isPlaying = value;

                    OnPausedOrPlaying(IsPlaying, new EventArgs());
                }
            }
        }

        public static event EventHandler? OnChangedSong;
        public static event EventHandler? OnPausedOrPlaying;
    }
}
