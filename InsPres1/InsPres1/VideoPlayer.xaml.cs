using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace InsPres1
{
    /// <summary>
    /// Interaction logic for VideoPlayer.xaml
    /// </summary>
    public partial class VideoPlayer : MetroWindow
    { 
        //private string _filePath;
        private System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public VideoPlayer(string fileName, string filePath)
        {
            
            InitializeComponent();
            VideoPlayerWindow.Title = fileName;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Tick += timerTick;
            mediaElement.Source = new Uri(filePath);
            mediaElement.Play();
           
            this.KeyUp += new KeyEventHandler(Play_Pause_button_KeyDown);
          
           
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Play_Pause_button.IsChecked.Value)
            {
                mediaElement.Pause();
                timer.Stop();
                Play_Pause_button.Content = FindResource("Play");
               // Play_Pause_button.IsChecked = false;
            }
            else
            {
                //rectPlay.OpacityMask.
                mediaElement.Play();
                timer.Start();
                Play_Pause_button.Content = FindResource("Pause");
              //  Play_Pause_button.IsChecked = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            if (Play_Pause_button.IsChecked.Value)
                Play_Pause_button.IsChecked = false;
            timer.Stop();
            Play_Pause_button.Content = FindResource("Play");
        }

        private void Volume_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void timerTick(object sender, EventArgs e)
        {
            Position_slider.Value = mediaElement.Position.TotalSeconds;
            //textBlock.Text = (int.Parse(mediaElement.Position.ToString()) / 10000).ToString();
            TimeSpan ts = mediaElement.Position;
           textBlock.Text =  String.Format("{0:00}:{1:00}:{2:00}",
            ts.Hours, ts.Minutes, ts.Seconds
           );
        }

        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            Position_slider.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalSeconds;
            mediaElement.Pause();
            timer.Start();
            TimeSpan ts = mediaElement.NaturalDuration.TimeSpan;
            textBlock1.Text = String.Format("{0:00}:{1:00}:{2:00}",
             ts.Hours, ts.Minutes, ts.Seconds
            ); 
       //     Play_Pause_button.Focus();

        }

        private void Position_slider_LostMouseCapture(object sender, MouseEventArgs e)
        {
            mediaElement.Position = TimeSpan.FromSeconds(Position_slider.Value);
            TimeSpan ts = mediaElement.Position;
            textBlock.Text = String.Format("{0:00}:{1:00}:{2:00}",
             ts.Hours, ts.Minutes, ts.Seconds
            );
            if (!Play_Pause_button.IsChecked.Value)
            {
                mediaElement.Pause();
                timer.Stop();
                Play_Pause_button.Content = FindResource("Play");
                Play_Pause_button.IsChecked = false;
            }
            else
            {
                //rectPlay.OpacityMask.
                mediaElement.Play();
                timer.Start();
                Play_Pause_button.Content = FindResource("Pause");
                Play_Pause_button.IsChecked = true;
            }
        }

        private void Play_Pause_button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.P)
            {
                if (Play_Pause_button.IsChecked.Value)
                {
                    mediaElement.Pause();
                    timer.Stop();
                    Play_Pause_button.Content = FindResource("Play");
                    Play_Pause_button.IsChecked = false;
                }
                else
                {
                    //rectPlay.OpacityMask.
                    mediaElement.Play();
                    timer.Start();
                    Play_Pause_button.Content = FindResource("Pause");
                    Play_Pause_button.IsChecked = true;
                }
            }
        }

        private void Position_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeSpan ts = mediaElement.Position;
            textBlock.Text = String.Format("{0:00}:{1:00}:{2:00}",
             ts.Hours, ts.Minutes, ts.Seconds
            );
        }

        private void Repeat_button_Click(object sender, RoutedEventArgs e)
        {
            if (!Repeat_button.IsChecked.Value)
            Repeat_button.Content = FindResource("RepeatG");
            else
                Repeat_button.Content = FindResource("RepeatB");
        }

        private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (Repeat_button.IsChecked.Value)
            {
                mediaElement.Stop();
                mediaElement.Play();
            }
            else
            {
                mediaElement.Stop();
                Play_Pause_button.Content = FindResource("Play");
                Play_Pause_button.IsChecked = false;
            }
        }

        private void Position_slider_GotMouseCapture(object sender, MouseEventArgs e)
        {
            mediaElement.Pause();
            timer.Stop();
        }

        private void mediaElement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Play_Pause_button.IsChecked.Value)
            {
                mediaElement.Pause();
                timer.Stop();
                Play_Pause_button.Content = FindResource("Play");
                Play_Pause_button.IsChecked = false;
            }
            else
            {
                //rectPlay.OpacityMask.
                mediaElement.Play();
                timer.Start();
                Play_Pause_button.Content = FindResource("Pause");
                Play_Pause_button.IsChecked = true;
            }

        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            cntlGrid.Visibility = Visibility.Visible;
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            cntlGrid.Visibility = Visibility.Hidden;
        }

        private void mediaElement_MouseLeave(object sender, MouseEventArgs e)
        {

        }
    }
}
