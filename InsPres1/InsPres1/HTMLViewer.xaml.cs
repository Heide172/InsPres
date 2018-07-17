using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Web;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using MahApps.Metro.Controls;
namespace InsPres1
{
    /// <summary>
    /// Interaction logic for HTMLViewer.xaml
    /// </summary>
    public partial class HTMLViewer : MetroWindow
    {
     

       
        public HTMLViewer(string fileName, string filePath)
        {
            InitializeComponent();
            HTMLViewerWindow.Title = fileName;
            var url = System.Web.HttpUtility.UrlEncode(filePath);
            WebBrowser.Navigate(url);
          
            
        }

      

       
       
    }
  
    
}
