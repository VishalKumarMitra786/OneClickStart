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
using System.IO;
using System.Diagnostics;

namespace OneClickStart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            this.OneStartMethod();
        }

        private void OneStartMethod(){
            var file = System.IO.Path.GetFullPath("./Config.txt");
            var isTextFileExist = File.Exists(file);
            try
            {
                
                if (isTextFileExist)
                {
                    string[] lines = File.ReadAllLines(file);
                    foreach (string filePath in lines)
                    {
                        //var isFileExist = File.Exists(filePath);
                        //if (isFileExist)
                        //{
                        var tempProcess = new Process();
                        tempProcess.StartInfo.FileName = filePath;
                        tempProcess.Start();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("The Specified Path: " + filePath + " doesn't exist");
               //         //}
                    }
                }
                else
                {
                    MessageBox.Show("You have deleted the Config.txt file or renamed it,Make the file with same name or rename the file to Config.txt if renamed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The Specified Path  doesn't exist ");
            }
            finally
            {
                this.Close();
            }
            
        }
    }
}
