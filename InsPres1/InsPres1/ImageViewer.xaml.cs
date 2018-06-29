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
    /// Interaction logic for ImageViewer.xaml
    /// </summary>
    public partial class ImageViewer : MetroWindow
    {
        public ImageViewer(string fileName, string filePath)
        {
            InitializeComponent();
            ImageViewerWindow.Title = fileName;
            ImageSourceConverter c = new ImageSourceConverter();
            Image.Source =  (ImageSource)c.ConvertFromString(filePath);
        }
    }
}
