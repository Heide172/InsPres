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

namespace InsPres1
{
    /// <summary>
    /// Interaction logic for toggleButton.xaml
    /// </summary>
    public partial class toggleButton : Window
    {
        public toggleButton()
        {
            InitializeComponent();
            this.Topmost = true;
            var primaryMonitorArea = SystemParameters.WorkArea;
            Left = primaryMonitorArea.Right - Width - 10;
            Top = primaryMonitorArea.Bottom - Height - 10;
            ToggleButton1.IsChecked = true;
            this.Deactivated += Form1_Deactivate;
          
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
                this.Topmost = true;

            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {

           
        }
    }
}
