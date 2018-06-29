using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//using System.Windows.Forms;
using JockerSoft.Media;

using System.Runtime.InteropServices;
using AxShockwaveFlashObjects;
namespace InsPres1
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
  
    public partial class EditWindow : Window
    {
        public delegate void ItemEdited(dataXML old, dataXML updated); // 
        public event ItemEdited OnItemEdited;
        private dataXML old;
        private string basePath;
        private itemPreview itemPreview1;
        public EditWindow(dataXML d, string bP)
        {
            try
            { 
            InitializeComponent();
            basePath = bP;
            if (d != default(dataXML))
            {
                name.Text = d.FileName;
                filePath.Text = d.FilePath;
               
                old = d;
            }
            else
                old = default(dataXML);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataXML data = new dataXML();
                if (name.Text != "")
                {
                    data.FileName = name.Text;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Enter File Name.");
                    return;
                }
                if (filePath.Text != "")
                {
                    if (Properties.Settings.Default.CopyResoursesToProjectFile)
                    {
                        if (!File.Exists(basePath + "\\Resources\\" + System.IO.Path.GetFileName(filePath.Text)))
                        {
                            File.Copy(filePath.Text, basePath + "\\Resources\\" + System.IO.Path.GetFileName(filePath.Text));
                            data.FilePath = basePath + "\\Resources\\" + System.IO.Path.GetFileName(filePath.Text);
                        }
                        else
                            data.FilePath = basePath + "\\Resources\\" + System.IO.Path.GetFileName(filePath.Text);
                    }
                    else
                        data.FilePath = filePath.Text;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Enter File Path.");
                    return;
                }

                data.FileType = getFileType(data.FilePath);
                if (old != null)
                {
                    if (old.FilePath != filePath.Text)
                        data.FilePreview = getPreview(data.FilePath, data.FileType);
                    else
                        data.FilePreview = old.FilePreview;
                }
                else// не работает
                {
                    data.FilePreview = getPreview(data.FilePath, data.FileType);
                }
                OnItemEdited(old, data);
                this.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
      
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog op = new System.Windows.Forms.OpenFileDialog();
                if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    filePath.Text = op.FileName;
                itemPreview1 = new itemPreview(op.FileName, getFileType(op.FileName));
                
                grid.Children.Add(itemPreview1);
                Grid.SetColumn(itemPreview1, 1);
                Grid.SetRow(itemPreview1, 2);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        
        private dataXML._FileType getFileType(string filePath)
        {
            try
            {
                string fileExt = System.IO.Path.GetExtension(filePath);
                if (String.Compare(fileExt, ".jpg", true) == 0)
                {
                    return dataXML._FileType.Image;
                }
                else if (String.Compare(fileExt, ".png", true) == 0)
                {
                    return dataXML._FileType.Image;
                }
                else if (String.Compare(fileExt, ".avi", true) == 0)
                {
                    return dataXML._FileType.Video;
                }
                else if (String.Compare(fileExt, ".wmv", true) == 0)
                {
                    return dataXML._FileType.Video;
                }
                else if (String.Compare(fileExt, ".mp4", true) == 0)
                {
                    return dataXML._FileType.Video;
                }
                else if (String.Compare(fileExt, ".html", true) == 0)
                {
                    return dataXML._FileType.Html;
                }
                else if (String.Compare(fileExt, ".swf", true) == 0)
                {
                    return dataXML._FileType.Flash;
                }
                else
                {
                    throw new Exception(Properties.Resources.UnsupportedExtMessage);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); return default(dataXML._FileType); }
        }
        private string getPreview(string filePath, dataXML._FileType fileType)
        {
            try
            {
                string prwPath = basePath + "\\Previews" + "\\" + System.IO.Path.GetFileName(filePath) + ".jpg";

                Rect bounds = VisualTreeHelper.GetDescendantBounds(itemPreview1);

                System.Windows.Point p0 = itemPreview1.PointToScreen(bounds.TopLeft);
                System.Drawing.Point p1 = new System.Drawing.Point((int)p0.X, (int)p0.Y);

                System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)bounds.Width, (int)bounds.Height);
                System.Drawing.Graphics imgGraphics = System.Drawing.Graphics.FromImage(image);

                imgGraphics.CopyFromScreen(p1.X, p1.Y,
                                           0, 0,
                                           new System.Drawing.Size((int)bounds.Width,
                                                                        (int)bounds.Height));

                image.Save(prwPath);
                return prwPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
           
        }
    }
}
