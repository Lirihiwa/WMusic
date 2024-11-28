using MediaManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMusic.GlobalUsageClasses;

namespace WMusic.UIClasses
{
    internal class MusicItem : Button
    {
        private string? _fullSource;
        private static object? _prev;
        public static Button NowPlaying { get { return (Button)_prev; } }
        public string FullSource { get { return _fullSource; } set { _fullSource = value; } }
        public MusicItem()
        {
            this.BackgroundColor = Colors.Blue;
            this.TextColor = Colors.White;
            this.BorderWidth = 2;
            this.BorderColor = Colors.Black;
            this.CornerRadius = 0;

            this.Clicked += OnButtonClicked;
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            if (_prev != null)
            {
                ((MusicItem)_prev).BackgroundColor = Colors.Blue;

            }
            _prev = sender;

            this.BackgroundColor = Colors.DarkOliveGreen;
            await PlayAudio("file://" + FullSource);
            MusicCurrentStatus.NowPlayingMusic = Text;
        }

        public async void ClickToThis() => OnButtonClicked(this, new EventArgs());

        public async Task PlayAudio(string filePath)
        {
            await CrossMediaManager.Current.Play(filePath);
            MusicCurrentStatus.IsPlaying = true;
        }

        public static async Task PlayPauseAudio()
        {
            await CrossMediaManager.Current.PlayPause();
            MusicCurrentStatus.IsPlaying = !CrossMediaManager.Current.IsPlaying();
        }
    }
}
