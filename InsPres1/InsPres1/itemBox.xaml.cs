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

namespace InsPres1
{
    /// <summary>
    /// Interaction logic for itemBox.xaml
    /// </summary>
    public partial class itemBox : UserControl
    {
        public delegate void buttonClick(dataXML._FileType fileType, string fileName, string path);
        public event buttonClick OnButtonClick;
        public delegate void deleteClick(dataXML item);
        public event deleteClick OnDeleteClick;
        public delegate void editItemClick(dataXML item);
        public event editItemClick OnEditItemClick;
        public delegate void NewItemClick();
        public event NewItemClick onNewItemClick;
        public dataXML _item;
        private bool Editing = false;
        const string basePath = "";
        public itemBox()
        {
            try
            {
                double height;
                double width;
                InitializeComponent();
                height = SystemParameters.PrimaryScreenHeight;
                width = SystemParameters.PrimaryScreenWidth;
                Grid1.Height = height / 4.5;
                Grid1.Width = width / 5.5;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        public void itemLoad(dataXML i)
        {
            try
            {
                _item = i;
                ItemButton.Content = _item.FileName;
                if (i.FileType != dataXML._FileType.Edit)
                {

                    ImageSourceConverter c = new ImageSourceConverter();
                  
                    FIleImage.Source = (ImageSource)c.ConvertFromString(i.FilePreview);
                }
                else
                {
                    FIleImage.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
         }

        public void editOn()
        {
            DeleteButton.Visibility = Visibility.Visible;
            Editing = true;
        }
        public void editOff()
        {
            DeleteButton.Visibility = Visibility.Hidden;
            Editing = false;
        }
        private void ItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_item.FileType == dataXML._FileType.Edit)
                {
                    onNewItemClick();
                }
                if (!Editing)
                {
                    OnButtonClick(_item.FileType, _item.FileName, _item.FilePath);
                }
                else
                    OnEditItemClick(_item);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            OnDeleteClick(_item);
        }
        
        

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_item.FileType == dataXML._FileType.Edit)
            {
                onNewItemClick();
            }
            if (!Editing)
            {
                OnButtonClick(_item.FileType, _item.FileName, _item.FilePath);
            }
            else
                OnEditItemClick(_item);
        }
    }
}
