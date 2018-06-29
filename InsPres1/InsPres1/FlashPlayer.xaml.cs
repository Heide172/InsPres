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
using System.Drawing;
using System.Drawing.Imaging;
using AxShockwaveFlashObjects;
using MahApps.Metro.Controls;
namespace InsPres1
{
    /// <summary>
    /// Interaction logic for FlashPlayer.xaml
    /// </summary>
    /// 
   
    public partial class FlashPlayer : MetroWindow
    {
        public AxShockwaveFlashObjects.AxShockwaveFlash AxShockwaveFlash;
       
        public FlashPlayer(string fileName, string filePath)
        {
            InitializeComponent();
            AxShockwaveFlash = new AxShockwaveFlash();
            Flash.Child = AxShockwaveFlash;
            FlashPlayerWindow.Title = fileName;
            (Flash.Child as AxShockwaveFlash).OnProgress += onReady;
            try
            {
                (Flash.Child as AxShockwaveFlash).CreateControl();
                (Flash.Child as AxShockwaveFlash).LoadMovie(0, filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.HResult);
            }
        }
        private void onReady(object sender, _IShockwaveFlashEvents_OnProgressEvent  e)
        {
            if (e.percentDone > 0.1)
            {
                Bitmap bmp = new Bitmap((Flash.Child as AxShockwaveFlash).Width, (Flash.Child as AxShockwaveFlash).Height);

                (Flash.Child as AxShockwaveFlash).DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save("1324324.jpg");
            }
            
        }


    }
}
