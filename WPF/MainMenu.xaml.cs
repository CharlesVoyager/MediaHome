using System;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Media.Animation;
using System.IO;
using System.Windows.Media;

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
        Storyboard btnBuildFadeOutStoryboard;
        Storyboard btnMaintenanceFadeOutStoryboard;
        Storyboard btnSettingsFadeOutStoryboard;

        private string selectedButton;
        public string SelectedButton
        {
            get { return selectedButton; }
            set { selectedButton = value; }
        }

        public MediaPlayer mediaPlayer;

        public MainMenu()
        {
            InitializeComponent();

            btnBuild.Content = "Print";
            btnMaintenance.Content = "Maintenance";
            btnSettings.Content = "Settings";


            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("SLS_panel_bg_loop_video.wmv", UriKind.Relative)); // Buildware Ver ~1.1.3: SLS_panel_bg_loop_video.mp4
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

        public void AnimateButtonBuildFadeOut()
        {
            btnBuildFadeOutStoryboard = FindResource("ButtonBuildFadeOut") as Storyboard;
            btnBuildFadeOutStoryboard.Begin();
        }

        public void AnimateButtonMaintenanceFadeOut()
        {
            btnMaintenanceFadeOutStoryboard = FindResource("ButtonMaintenanceFadeOut") as Storyboard;
            btnMaintenanceFadeOutStoryboard.Begin();
        }

        public void AnimateButtonSettingsFadeOut()
        {
            btnSettingsFadeOutStoryboard = FindResource("ButtonSettingsFadeOut") as Storyboard;
            btnSettingsFadeOutStoryboard.Begin();
        }

        public void DisableMainMenuButtons()
        {
            btnBuild.IsEnabled = false;
            btnMaintenance.IsEnabled = false;
            btnSettings.IsEnabled = false;
        }

        public void EnableMainMenuButtons()
        {
            btnBuild.IsEnabled = true;
            btnMaintenance.IsEnabled = true;
            btnSettings.IsEnabled = true;
        }
        //<><><>

        private void btnMaintenance_Click(object sender, RoutedEventArgs e)
        {
            Button selected = sender as Button;
            selectedButton = selected.Name;

            AnimateButtonBuildFadeOut();
            AnimateButtonSettingsFadeOut();

            AnimateButtonGrow();
            DisableMainMenuButtons();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Button selected = sender as Button;
            selectedButton = selected.Name;

            AnimateButtonBuildFadeOut();
            AnimateButtonMaintenanceFadeOut();

            AnimateButtonGrow();
            DisableMainMenuButtons();
        }

        // MainMenu: Print button
        private void btn_Build_Click(object sender, RoutedEventArgs e)
        {
            Button selected = sender as Button;
            selectedButton = selected.Name;

            AnimateButtonMaintenanceFadeOut();
            AnimateButtonSettingsFadeOut();

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
            AnimateButtonBuildFadeOut();
            AnimateButtonMaintenanceFadeOut();
            AnimateButtonSettingsFadeOut();

            switch (SelectedButton)
            {
                case "btnBuild":    //Print

                    break;
                case "btnMaintenance":


                    break;

                case "btnSettings":

                    break;
            }
        }

        void btnBuildFadeOutAnimationStoryboard_Completed(object sender, EventArgs e)
        {
            btnBuildFadeOutStoryboard.Stop();
        }

        void btnMaintenanceFadeOutAnimationStoryboard_Completed(object sender, EventArgs e)
        {
            btnMaintenanceFadeOutStoryboard.Stop();
        }

        void btnSettingsFadeOutAnimationStoryboard_Completed(object sender, EventArgs e)
        {
            btnSettingsFadeOutStoryboard.Stop();
        }
    }
}
