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
using WinForms = System.Windows.Forms;
using System.IO.Compression;
using System.IO;

namespace FTTDUp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtondirOut_Click(object sender, RoutedEventArgs e)
        {
            WinForms.OpenFileDialog openFile = new WinForms.OpenFileDialog();
            openFile.Filter = "ZIP files (*.zip)|*.zip";
            openFile.ShowDialog();
            TextBoxdirOut.Text = openFile.FileName;
        }

        private void ButtonUPDATE_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(@"Update")) Directory.Delete(@"Update", true);
            ZipFile.ExtractToDirectory(@"" + TextBoxdirOut.Text, @"Update");
            DirectoryInfo source = new DirectoryInfo(@"Update\\");
            foreach (var item in source.GetFiles()) item.CopyTo(Environment.CurrentDirectory+ "\\" + item.Name, true);
            Directory.Delete(@"Update", true);
            FileInfo fi = new FileInfo(@"Fttd.txt");
            fi.CopyTo(Environment.CurrentDirectory + "\\Fttd.exe", true);
            fi.Delete();
            this.Title = "FTTD успешно обновлена";
        }
    }
}
