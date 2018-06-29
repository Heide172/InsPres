using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InsPres1;
using System.IO;
using System.Xml.Serialization;
using JockerSoft.Media;
namespace PresetCreator
{
    public partial class Form1 : Form
    {
        const string basePath = "";
        List<dataXML> Preset;
        public Form1()
        {
            InitializeComponent();
            Preset = new List<dataXML>();
            string[] s;
            foreach (dataXML._FileType fileType in Enum.GetValues(typeof(dataXML._FileType)))
            {
                comboBox1.Items.Add(fileType);
            }
            
        }

        private void File_Open_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog of = new OpenFileDialog();
                of.ShowDialog();
                textBox2.Text = of.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка открытия файла." + ex.Message);
            }
        }

        private void File_Add_Click(object sender, EventArgs e)
        {
            dataXML d = new dataXML();
            if (textBox1.Text == "") MessageBox.Show("Введите имя файла");
            else
            {
                if (textBox2.Text == "") MessageBox.Show("Введите путь к файлу");
                else
                {
                    if (comboBox1.SelectedIndex == -1) MessageBox.Show("Выберите тип файла");
                    else
                    {
                        d.FileName = textBox1.Text;
                        d.FilePath = textBox2.Text;
                        d.FileType = (dataXML._FileType)comboBox1.SelectedItem;
                    }
                } 
                
            }
            try
            {
                switch (d.FileType)
                {
                    case dataXML._FileType.Video:
                        if (textBox4.Text != "")
                        {
                            d.FilePreview = textBox4.Text;
                        }
                        else
                        {
                            string prwPath = basePath + "Preview" + @"\" + d.FileName + "Preview.jpg";
                            FrameGrabber.SaveFrameFromVideo(d.FilePath, 0.01d, prwPath);
                            d.FilePreview = prwPath;
                        }
                        Preset.Add(d);
                        listBox1.Items.Add(d.FileName);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox4.Text = "";
                        comboBox1.SelectedIndex = -1;

                        break;
                    case dataXML._FileType.Flash:
                        if (textBox4.Text != "")
                        {
                            d.FilePreview = textBox4.Text;
                        }
                        else
                        {
                            string prwPath1 = basePath + "prw.jpg";
                            d.FilePreview = prwPath1;
                        }
                       
                        listBox1.Items.Add(d.FileName);
                        Preset.Add(d);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox4.Text = "";
                        comboBox1.SelectedIndex = -1;
                        break;
                    case dataXML._FileType.Html:
                        if (textBox4.Text != "")
                        {
                            d.FilePreview = textBox4.Text;
                        }
                        else
                        {
                            string prwPath2 = basePath + "prw.jpg";
                            d.FilePreview = prwPath2;
                        }
                       
                        listBox1.Items.Add(d.FileName);
                        Preset.Add(d);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox4.Text = "";
                        comboBox1.SelectedIndex = -1;
                        break;
                    case dataXML._FileType.Image:
                        if (textBox4.Text != "")
                        {
                            d.FilePreview = textBox4.Text;
                        }
                        else
                        {
                            string prwPath3 = basePath + d.FilePath;
                            d.FilePreview = prwPath3;
                        }
                        listBox1.Items.Add(d.FileName);
                        Preset.Add(d);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox4.Text = "";
                        comboBox1.SelectedIndex = -1;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении файла в пресет. " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<dataXML>));
            if (textBox3.Text == "") MessageBox.Show("Введите имя для сохранения. ");
            else
            {
                string prPath = basePath + "Presets" + @"\" + textBox3.Text + ".xml";
                using (FileStream fs = new FileStream(prPath, FileMode.OpenOrCreate))
                {
                    ser.Serialize(fs, Preset);
                    MessageBox.Show("Готово. ");
                }
                textBox3.Text = "";
                listBox1.Items.Clear();
                Preset = new List<dataXML>();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog of = new OpenFileDialog();
                of.ShowDialog();
                textBox4.Text = of.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка открытия файла." + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
