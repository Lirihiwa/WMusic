using MediaManager;
using System.IO;
using System.Linq;
using WMusic.GlobalUsageClasses;
using WMusic.LogicClasses;
using WMusic.LogicClasses.InteractionWithFileSystem;
using WMusic.UIClasses;
using static System.Net.Mime.MediaTypeNames;

namespace WMusic;

public partial class MusicViewerPage : ContentPage
{
    public MusicViewerPage()
    {
        InitializeComponent();
            
        FileManager.SearchInDirectoryRecursive("/storage/emulated/0/", new MP3Format(), new OGGFormat(), new WAVFormat());

        foreach (var musicFiles in MusicContainer.MusicFiles)
        {
            MusicList.Children.Add(new MusicItem() { Text = musicFiles.Split('/').ToArray()[^1], FullSource = musicFiles });
        }

        MusicCurrentStatus.OnChangedSong += ChangeNowPlayingSongInfo;
        MusicCurrentStatus.OnPausedOrPlaying += OnPlayPause;
    }

    private void OnPlayPause(object sender, EventArgs e)
    {
        if ((bool)sender) PlayPause.Text = "Playing";
        else PlayPause.Text = "Paused";
    }

    private async void OnPlayPauseClicked(object sender, EventArgs e)
    {
        if(MusicItem.NowPlaying == null) 
        {
            return;
        }

        Button button = sender as Button;

        if (button.Text == "Paused") button.Text = "Playing";
        if (button.Text == "Playing") button.Text = "Paused";

        await MusicItem.PlayPauseAudio();
    }

    private void OnPrevClicked(object sender, EventArgs e)
    {
        int index = MusicList.Children.IndexOf(MusicItem.NowPlaying);
        
        try
        {
            var next = MusicList.Children[index - 1];

            ((MusicItem)next).ClickToThis();
        }
        catch (Exception ex)
        {
            if(index >= 0) ((MusicItem)MusicList.Children[index]).ClickToThis();
        }
    }

    private void OnNextClicked(object sender, EventArgs e)
    {
        int index = MusicList.Children.IndexOf(MusicItem.NowPlaying);

        try
        {
            var next = MusicList.Children[index + 1];

            ((MusicItem)next).ClickToThis();
        }
        catch (Exception ex) 
        {
            if(index >= 0) ((MusicItem)MusicList.Children[index]).ClickToThis();
        }
        
    }

    private void ChangeNowPlayingSongInfo(object sender, EventArgs e)
    {
        NowPlaying.Text = "Now playing: " + MusicCurrentStatus.NowPlayingMusic;
    }

    private void OpenMusicPlayer(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new MusicPlayer());
    }
}