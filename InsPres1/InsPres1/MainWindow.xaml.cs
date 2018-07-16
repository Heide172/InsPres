using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.IO;
using System.Diagnostics;
using JockerSoft.Media;
using System.Reflection;
using System.Xml.Serialization;
namespace InsPres1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        List<dataXML> CurrentPreset; // рабочий пресет
        string defaultPath; // путь пресета по умолчанию, для работы не создавая пресет
        string CurrentPresetPath; // путь рабочего пресета 
        toggleButton toggleButton1 = new toggleButton(); // кпнока для сворачивания
        bool isEditing = false; // флаг режима редактирования
        public MainWindow()
        {
            defaultPath = System.Windows.Forms.Application.StartupPath + "\\Presets\\Default"; // запись пути по умолчанию
            try// очистка папки по умолчанию
            {
                
                if (!Directory.Exists(defaultPath + "//Resources"))
                    Directory.CreateDirectory(defaultPath + "//Resources");
               
                if (!Directory.Exists(defaultPath + "//Previews"))
                    Directory.CreateDirectory(defaultPath + "//Previews");

                DirectoryInfo dir1 = new DirectoryInfo(defaultPath + "//Resources");
                foreach (FileInfo file in dir1.GetFiles())
                {
                    file.Delete();
                }
                DirectoryInfo dir2 = new DirectoryInfo(defaultPath + "//Previews");
                foreach (FileInfo file in dir2.GetFiles())
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<dataXML>));
                using (FileStream fs = new FileStream(defaultPath + "\\config.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, new List<dataXML>());
                }
            }
            catch (Exception)
            {
                throw;
            }
            CurrentPresetPath = defaultPath;

            try
            {
               
                CurrentPreset = new List<dataXML>();
               
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            toggleButton1.ToggleButton1.Click += toggleButtonClick;
            toggleButton1.Show();
          

            Closing += onClosing;
        }

        private void onClosing(object sender, System.ComponentModel.CancelEventArgs e) // отображение окна предупреждения при закрытии приложения
        {
            try
            {
                if (CurrentPreset.Count != 0 && CurrentPresetPath == System.Windows.Forms.Application.StartupPath + "\\Presets\\Default")
                {
                    ExitWindow ew = new ExitWindow();
                    ew.ShowDialog();
                    switch (ew.DialogResult)
                    {
                        case 0:
                            e.Cancel = true;
                            break;
                        case 1:
                            Preset.SaveAs(CurrentPreset, CurrentPresetPath);
                            break;
                        case 2:

                            break;
                    }
                }
                else
                    Preset.Save(CurrentPreset, CurrentPresetPath, CurrentPresetPath);


                toggleButton1.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void toggleButtonClick(object sender, RoutedEventArgs e)
        {


            if (!toggleButton1.ToggleButton1.IsChecked.Value)
                this.WindowState = WindowState.Minimized;

            else
                this.WindowState = WindowState.Normal;
        }
       


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (menu.Visibility == Visibility.Visible)
                menu.Visibility = Visibility.Collapsed;
            else
                menu.Visibility = Visibility.Visible;

        }


        private void menu_MouseLeave(object sender, MouseEventArgs e)
        {
            if (menu.Visibility == Visibility.Visible)
                menu.Visibility = Visibility.Collapsed;
        }
        private void onItemClick(dataXML._FileType fileType, string fileName, string path)
        {
            try
            {
               // string fullFilePath = CurrentPresetPath + "\\" + path;
                switch (fileType)
                {
                    case dataXML._FileType.Video:
                        VideoPlayer vp = new VideoPlayer(fileName, path);
                        vp.Show();
                        break;
                    case dataXML._FileType.Flash:
                        FlashPlayer fp = new FlashPlayer(fileName, path);
                        fp.Show();
                        break;
                    case dataXML._FileType.Html:
                        HTMLViewer hv = new HTMLViewer(fileName, path);
                        hv.Show();
                        break;
                    case dataXML._FileType.Image:
                        ImageViewer iv = new ImageViewer(fileName, path);
                        iv.Show();
                        break;
                    case dataXML._FileType.Edit:
                        break;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void onDeleteClick(dataXML d)
        {
            try
            {
                foreach (dataXML data in CurrentPreset)
                {
                    if (data == d)
                    {
                        CurrentPreset.Remove(data);

                        Panel1.Items.Clear();
                        foreach (dataXML data1 in CurrentPreset)
                        {
                            Panel1.Items.Add(CreateNewItemBox(data1));
                        }
                        foreach (itemBox i in Panel1.Items)
                        {
                            i.editOn();
                        }
                        Panel1.Items.Add(CreateNewItemBox());
                        break;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }
        private void onEditClick(dataXML d)
        {
            try
            {
                EditWindow ed = new EditWindow(d, CurrentPresetPath);

                ed.Show();
                ed.OnItemEdited += onItemEdited;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void onItemEdited(dataXML old, dataXML updated)
        {
            try
            {
                foreach (dataXML data in CurrentPreset)
                {
                    if (data == old)
                    {
                        data.FileName = updated.FileName;
                        data.FilePath = updated.FilePath;
                        data.FilePreview = updated.FilePreview;
                        data.FileType = updated.FileType;

                        Panel1.Items.Clear();
                        foreach (dataXML data1 in CurrentPreset)
                        {
                            dataXML viewData = data1;
                            viewData.FilePath = CurrentPresetPath  + viewData.FilePath;
                            viewData.FilePreview = CurrentPresetPath  + viewData.FilePreview;
                            Panel1.Items.Add(CreateNewItemBox(data1));
                        }
                        foreach (itemBox i in Panel1.Items)
                        {
                            i.editOn();
                        }
                        Panel1.Items.Add(CreateNewItemBox());
                        break;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    

        private void OnNewItemClick()
        {
            EditWindow ed = new EditWindow(default(dataXML), CurrentPresetPath);
            ed.OnItemEdited += OnNewItemCreated;
            ed.Show();
        }

        private void OnNewItemCreated(dataXML d, dataXML data)
        {
            CurrentPreset.Add(data);
            Panel1.Items.Clear();
            foreach (dataXML data1 in CurrentPreset)
            {
               
                Panel1.Items.Add(CreateNewItemBox(data1));
            }
            foreach (itemBox i in Panel1.Items)
            {
                i.editOn();
            }
            Panel1.Items.Add(CreateNewItemBox());

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            Panel1.Items.Clear();
            foreach (dataXML data1 in CurrentPreset)
            {
                Panel1.Items.Add(CreateNewItemBox(data1));
            }
            button.Visibility = Visibility.Hidden;
        }
        private itemBox CreateNewItemBox(dataXML data) // создание нового элемента itemBox
        {
            itemBox item = new itemBox();
            item.Margin = new Thickness(0, 5, 0, 5);
            dataXML viewData = new dataXML();
            viewData.FileName = data.FileName;
            viewData.FilePath = data.FilePath;
            viewData.FilePreview = data.FilePreview;
            viewData.FileType = data.FileType;
            viewData.FilePath = CurrentPresetPath + viewData.FilePath;
            viewData.FilePreview = CurrentPresetPath +  viewData.FilePreview;
            item.itemLoad(viewData);
            item.OnButtonClick += onItemClick;
            item.OnDeleteClick += onDeleteClick;
            item.OnEditItemClick += onEditClick;
            return item;
        }

        private itemBox CreateNewItemBox() // создание пустого элемента itemBox "Add new item"
        {
            itemBox add = new itemBox();
            dataXML edit = new dataXML();
            edit.FileName = Properties.Resources.AddNewItemText;
            edit.FileType = dataXML._FileType.Edit;
            add.OnButtonClick += onItemClick;
            add.OnDeleteClick += onDeleteClick;
            add.OnEditItemClick += onEditClick;
            add.onNewItemClick += OnNewItemClick;
            add.itemLoad(edit);
            
            return add;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) // Создание нового проекта
        {
            try
            {
                if (CurrentPreset.Count != 0)
                {

                    ExitWindow ew = new ExitWindow();
                    ew.ShowDialog();
                    switch (ew.DialogResult)
                    {
                        case 0: // отмена
                            return;
                        case 1: // сохранить
                            if (CurrentPresetPath == System.Windows.Forms.Application.StartupPath + "\\Presets\\Default")
                            {
                                Preset.SaveAs(CurrentPreset, CurrentPresetPath);
                            }
                            else
                            {
                                Preset.Save(CurrentPreset, CurrentPresetPath, CurrentPresetPath);
                            }
                            break;
                        case 2: // закрыть

                            CurrentPreset = new List<dataXML>();
                            Panel1.Items.Clear();
                            if (!Directory.Exists(defaultPath + "//Resources"))
                                Directory.CreateDirectory(defaultPath + "//Resources");

                            if (!Directory.Exists(defaultPath + "//Previews"))
                                Directory.CreateDirectory(defaultPath + "//Previews");

                            DirectoryInfo dir1 = new DirectoryInfo(defaultPath + "//Resources");
                            foreach (FileInfo file in dir1.GetFiles())
                            {
                                file.Delete();
                            }
                            DirectoryInfo dir2 = new DirectoryInfo(defaultPath + "//Previews");
                            foreach (FileInfo file in dir2.GetFiles())
                            {
                                file.Delete();
                            }

                            break;
                    }
                    Panel1.Items.Clear();
                    CurrentPresetPath = defaultPath;
                }

            
            


                //CurrentPresetPath = Preset.CreateNew();
                //object s = new object();
                //RoutedEventArgs rea = new RoutedEventArgs();
                //MenuItem_Click_3(s,rea);
            }
            catch (Exception ex)
            {
                if (ex.Message != Properties.Resources.FileDialogExitMessage)
                    MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)// включение режима редактирования
        {
            if (!isEditing) // если режим редактирования выключен - включить
            {
                foreach (itemBox i in Panel1.Items)
                {
                    i.editOn();
                }
                Panel1.Items.Add(CreateNewItemBox());
              
                isEditing = true;
            }
            else // -//-
            {
                Panel1.Items.Clear();
                foreach (dataXML data1 in CurrentPreset)
                {
                    Panel1.Items.Add(CreateNewItemBox(data1));
                }
                isEditing = false;
            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e) // Открытие проекта
        {
            try
            {
                CurrentPresetPath = Preset.Open();
                XmlSerializer formatter = new XmlSerializer(typeof(List<dataXML>));
                using (FileStream fs = new FileStream(CurrentPresetPath + "\\config.xml", FileMode.OpenOrCreate))
                {
                    CurrentPreset = (List<dataXML>)formatter.Deserialize(fs);
                }
                Panel1.Items.Clear();
                foreach (dataXML data1 in CurrentPreset)
                {
                    Panel1.Items.Add(CreateNewItemBox(data1));
                }
            }
            catch(Exception ex)
            {
                if (ex.Message != Properties.Resources.FileDialogExitMessage)
                    MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e) // Сохранение проекта
        {
            try
            {
                if (CurrentPresetPath != defaultPath)
                    Preset.Save(CurrentPreset, CurrentPresetPath, CurrentPresetPath);
                else
                    CurrentPresetPath = Preset.SaveAs(CurrentPreset, CurrentPresetPath);
            }
            catch (Exception ex)
            {
                if (ex.Message != Properties.Resources.FileDialogExitMessage)
                    MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e) // Сохранение в новый проект
        {
            try
            {
                
                CurrentPresetPath = Preset.SaveAs(CurrentPreset, CurrentPresetPath);
            }
            catch (Exception ex)
            {
                if (ex.Message != Properties.Resources.FileDialogExitMessage)
                    MessageBox.Show(ex.Message);
            }
        }
    }

    static class Preset
    {
        public static string CreateNew() // Создает новый каталог проекта и возвращает корневую дирректорию этого каталога
        {
            string basePath;
            try
            {
                CreateNewWindow createNew = new CreateNewWindow();
                if ((bool)createNew.ShowDialog())
                {
                    basePath = createNew.FilePath;
                    try
                    {
                        Directory.CreateDirectory(basePath);
                        Directory.CreateDirectory(basePath + "\\Resources");
                        Directory.CreateDirectory(basePath + "\\Previews");
                    }
                    catch (Exception ex)
                    { throw ex; }
                    return basePath;
                }
                else
                    throw new Exception(Properties.Resources.FileDialogExitMessage);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public static string Open() // Открывает проект и возвращает дирректорию этого проекта
        {
            string path;
            List<dataXML> dataList = new List<dataXML>();
            try
            {
                
                System.Windows.Forms.FolderBrowserDialog fb = new System.Windows.Forms.FolderBrowserDialog();
                fb.ShowNewFolderButton = false;
                fb.SelectedPath = System.Windows.Forms.Application.StartupPath;

                if (fb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    path = fb.SelectedPath;
                    if (System.IO.File.Exists(path + "\\config.xml"))
                    { 
                        return path;
                    }
                    else
                    {
                        throw new Exception(Properties.Resources.FileNotFoundErrMessage);
                    }

                }
                else
                    throw new Exception(Properties.Resources.FileDialogExitMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Save(List<dataXML> dataList, string path, string c) // сохраняет изменения в изначальный проект
        {
            try
            {
                
                foreach (dataXML data in dataList)
                {
                    if (!System.IO.File.Exists(path + data.FilePath))
                    {
                        System.IO.File.Copy(c + data.FilePath, path + "\\Resources\\" + data.FileName + System.IO.Path.GetExtension(data.FilePath));
                        data.FilePath =   "\\Resources\\" + data.FileName + System.IO.Path.GetExtension(data.FilePath);
                        System.IO.File.Copy(c + data.FilePreview, path + "\\Previews\\" + data.FileName + System.IO.Path.GetExtension(data.FilePath) + ".jpg");
                        data.FilePreview =   "\\Previews\\" + data.FileName + System.IO.Path.GetExtension(data.FilePath) + ".jpg";
                    }
                }
                XmlSerializer formatter = new XmlSerializer(typeof(List<dataXML>));
                using (FileStream fs = new FileStream(path + "\\config.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, dataList);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string SaveAs(List<dataXML> dataList, string currentPresetPath) // сохраняет текущий проект в новую дирректорию
        {
            try
            {
                string path = Preset.CreateNew();
                Preset.Save(dataList, path , currentPresetPath);
                return path;
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
   
}
