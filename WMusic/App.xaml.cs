namespace WMusic
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MusicViewerPage();
        }
    }
}
