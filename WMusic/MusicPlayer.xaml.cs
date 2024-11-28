namespace WMusic;

public partial class MusicPlayer : ContentPage
{
	public MusicPlayer()
	{
		InitializeComponent();
	}

	private void Initialize()
	{

	}

	private void Return(object sender, EventArgs e)
	{
		Navigation.PopModalAsync();
	}
}