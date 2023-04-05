using Microsoft.Win32;
using System;
using System.Windows;

namespace RenameMultipleFiles
{
    public partial class OpenFileDialogMultipleFilesSample : Window
    {
        public OpenFileDialogMultipleFilesSample()
        {
            InitializeComponent();
        }

        private void btnOpenFiles_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Multiselect = true,
                Filter = "Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            if (openFileDialog.ShowDialog() == true)
            {
                lbFiles.Items.Clear();
                foreach (string filename in Renamer.Files.Rename(
                            openFileDialog.FileNames,
                            txtOldPart.Text,
                            txtNewPart.Text))
                {
                    lbFiles.Items.Add(filename);
                }
            }
        }
    }
}
