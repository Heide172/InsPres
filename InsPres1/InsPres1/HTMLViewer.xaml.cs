﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Web;
using System.Windows.Controls;
using System.Text.RegularExpressions;
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
     

       
        public HTMLViewer(string fileName, string _filePath)
        {
            InitializeComponent();
            HTMLViewerWindow.Title = fileName;
            string filePath = PathEncode(_filePath);
            WebBrowser.Navigate(filePath);
          
            
        }

        /// <summary>
        /// Выявление кирилицы в пути и ее кодирование
        /// </summary>
        /// <param name="filePath"> Изначальный путь </param>
        /// <returns> Путь с закодированой кирилицей</returns>
        private string PathEncode(string filePath)
        {
            string encodedPath = filePath;
            foreach (char _sym in encodedPath)
            {
                string sym = _sym.ToString();
                if (Regex.IsMatch(sym.ToString(), "^[А-Яа-я]+$"))
                {
                    encodedPath = encodedPath.Replace(sym,
                       System.Web.HttpUtility.UrlEncode(sym));
                }
            }
            return encodedPath;
        }
      

       
       
    }
  
    
}
