using System;
using System.Linq;
using System.Windows;
using EncodeDecode;

namespace EncodeDecodeUI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBrowseClick(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            //dlg.DefaultExt = "*.*";
            //dlg.Filter = "Text documents (.txt)|*.txt";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                txtFileName.Text = filename;
            }
        }

        private void BtnEncodeClick(object sender, RoutedEventArgs e)
        {
            if (EncodeOption.IsChecked == true)
            {
                txtOutput.Text = Coder.EncodeFile(txtFileName.Text);
            }
            else
            {
                Coder.DecodeToFile(txtOutput.Text, txtFileName.Text);
            }
        }
    }
}