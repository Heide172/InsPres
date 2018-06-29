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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AxShockwaveFlashObjects;

namespace InsPres1
{
    /// <summary>
    /// Interaction logic for itemPreview.xaml
    /// </summary>
    public partial class itemPreview : UserControl
    {
        public itemPreview(string filePath, dataXML._FileType fileType)
        {
            InitializeComponent();
            try
            {
                switch (fileType)
                {
                    case dataXML._FileType.Flash:
                        WebBrowser wb1 = new WebBrowser();
                        wb1.Navigate(filePath);
                        panel.Children.Add(wb1);
                        break;
                    case dataXML._FileType.Html:
                        WebBrowser wb = new WebBrowser();
                        wb.Navigate(filePath);
                        panel.Children.Add(wb);
                        break;
                    case dataXML._FileType.Video:
                        MediaElement me = new MediaElement();
                        me.Source = new Uri(filePath);
                        me.UnloadedBehavior = MediaState.Manual;
                        me.Volume = 0;
                        me.Play();
                        panel.Children.Add(me);
                        break;
                    case dataXML._FileType.Image:
                        Image img = new Image();
                        ImageSourceConverter c = new ImageSourceConverter();
                        img.Source = (ImageSource)c.ConvertFromString(filePath);
                        panel.Children.Add(img);
                        break;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            
        }
    }
}
