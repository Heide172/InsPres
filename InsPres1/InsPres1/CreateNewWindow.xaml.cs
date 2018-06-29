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
    /// Interaction logic for CreateNewWindow.xaml
    /// </summary>
    public partial class CreateNewWindow : Window
    {
        public delegate string ProjectCreated();
        public event ProjectCreated OnProjectCreated;

        public string FilePath;
        public CreateNewWindow()
        {
            InitializeComponent();
        }

        private void OpenPathButton_Click(object sender, RoutedEventArgs e)// Выбор дирректории для сохранения проекта
        {
            System.Windows.Forms.FolderBrowserDialog fb = new System.Windows.Forms.FolderBrowserDialog();
            fb.SelectedPath = System.Windows.Forms.Application.StartupPath;
            if (fb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                PathTextBox.Text = fb.SelectedPath; 

        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e) // Проверка заполнения формы и сохранение дирректории
        {
            if (NameTextBox.Text != null)
            {
                if (PathTextBox.Text != null)
                {
                    FilePath = PathTextBox.Text +"\\" + NameTextBox.Text;
                    Properties.Settings.Default.CopyResoursesToProjectFile = (bool)CopyResourcesCheck.IsChecked;
                    this.DialogResult = true;
                    
                }
                else
                    MessageBox.Show(Properties.Resources.EnterPathMessage);
            }
            else
                MessageBox.Show(Properties.Resources.EnterNameMessage);
        }
    }
}
