using System;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Media.Animation;
using System.IO;
using System.Windows.Media;
using System.Diagnostics;

namespace MediaHome.WPF
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public const string LOG_TAG = "MainMenu";

        Storyboard btnGrowStoryboard;
        Storyboard btnFadeInStoryboard;
        Storyboard btnNetflixFadeOutStoryboard;
        Storyboard btnDisneyPlusFadeOutStoryboard;
        Storyboard btnYoutubeFadeOutStoryboard;

        private string selectedButton;
        public string SelectedButton
        {
            get { return selectedButton; }
            set { selectedButton = value; }
        }

        private MediaPlayer mediaPlayer;

        public MainMenu()
        {
            InitializeComponent();

            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("BackgroundVideo.mp4", UriKind.Relative)); // backgroundvideo.mp4 comes from https://www.pexels.com/search/videos/background/, Pexels Videos 1851190.mp4.
            mediaPlayer.MediaEnded += mediaPlayer_MediaEnded;
            mediaPlayer.ScrubbingEnabled = true;
            VideoDrawing drawing = new VideoDrawing();
            drawing.Rect = new Rect(0, 0, 600, 800);
            drawing.Player = mediaPlayer;
            mediaPlayer.Play();
            DrawingBrush brush = new DrawingBrush(drawing);
            this.Background = brush;
        }

        private void mediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            mediaPlayer.Position = TimeSpan.Zero;
        }

        //<Added to animate the main menu buttons through the use of storyboard>
        public void AnimateButtonFadeIn()
        {
            btnFadeInStoryboard = FindResource("ButtonMainMenuAllFadeIn") as Storyboard;
            btnFadeInStoryboard.Begin();
        }

        public void AnimateButtonGrow()
        {
            btnGrowStoryboard = FindResource("ButtonGrow") as Storyboard;

            foreach (var animation in btnGrowStoryboard.Children)
            {
                Storyboard.SetTargetName(animation, selectedButton);
            }

            btnGrowStoryboard.Begin();
        }

        public void AnimateButtonNetflixFadeOut()
        {
            btnNetflixFadeOutStoryboard = FindResource("ButtonNetflixFadeOut") as Storyboard;
            btnNetflixFadeOutStoryboard.Begin();
        }

        public void AnimateButtonDisneyPlusFadeOut()
        {
            btnDisneyPlusFadeOutStoryboard = FindResource("ButtonDisneyPlusFadeOut") as Storyboard;
            btnDisneyPlusFadeOutStoryboard.Begin();
        }

        public void AnimateButtonYoutubeFadeOut()
        {
            btnYoutubeFadeOutStoryboard = FindResource("ButtonYoutubeFadeOut") as Storyboard;
            btnYoutubeFadeOutStoryboard.Begin();
        }

        public void DisableMainMenuButtons()
        {
        }

        public void EnableMainMenuButtons()
        {
        }
        //<><><>

   
        private void btnNetflix_Click(object sender, RoutedEventArgs e)
        {
            Button selected = sender as Button;
            selectedButton = selected.Name;

            AnimateButtonDisneyPlusFadeOut();
            AnimateButtonYoutubeFadeOut();

            AnimateButtonGrow();
            DisableMainMenuButtons();
        }

        private void btnDisneyPlus_Click(object sender, RoutedEventArgs e)
        {
            Button selected = sender as Button;
            selectedButton = selected.Name;

            AnimateButtonNetflixFadeOut();
            AnimateButtonYoutubeFadeOut();

            AnimateButtonGrow();
            DisableMainMenuButtons();
        }

        private void btnYoutube_Click(object sender, RoutedEventArgs e)
        {
            Button selected = sender as Button;
            selectedButton = selected.Name;

            AnimateButtonNetflixFadeOut();
            AnimateButtonDisneyPlusFadeOut();

            AnimateButtonGrow();
            DisableMainMenuButtons();
        }

        void btnMainMenuAllFadeInAnimationStoryboard_Completed(object sender, EventArgs e)
        {
            btnFadeInStoryboard.Stop();
        }

        void btnGrowAnimationStoryboard_Completed(object sender, EventArgs e)
        {
            btnGrowStoryboard.Stop();
            AnimateButtonNetflixFadeOut();
            AnimateButtonDisneyPlusFadeOut();
            AnimateButtonYoutubeFadeOut();

            switch (SelectedButton)
            {
                case "btnNetflix":
                    //brdWeb.Visibility = Visibility.Visible;
                    //StartWeb.Navigate("https://www.netflix.com/tw-en/");
                    break;

                case "btnDisneyPlus":

                    break;

                case "btnYoutube":
                    //brdWeb.Visibility = Visibility.Visible;
                    //StartWeb.Navigate("https://m.youtube.com/index?app=m");

                    LaunchYoutube();

                    break;
            }
        }

        private void btnNetflixFadeOutAnimationStoryboard_Completed(object sender, EventArgs e)
        {
            btnNetflixFadeOutStoryboard.Stop();
        }

        private void btnDisneyPlusFadeOutAnimationStoryboard_Completed(object sender, EventArgs e)
        {
            btnDisneyPlusFadeOutStoryboard.Stop();
        }

        void btnYoutubeFadeOutAnimationStoryboard_Completed(object sender, EventArgs e)
        {
            btnYoutubeFadeOutStoryboard.Stop();
        }


        void LaunchYoutube()
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\Chrome.exe";

            process.StartInfo.Arguments = "--kiosk --app=m.youtube.com/index?app=m";
            process.Start();
        }
    }
}
