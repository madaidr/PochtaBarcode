using System.IO;
using System.Windows;
using System.Windows.Forms;
using IronBarCode;
//using System.Drawing;

namespace PochtaBarcode
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GeneratedBarcode MyBarCode = BarcodeWriter.CreateBarcode("80110960014354", BarcodeWriterEncoding.ITF).ResizeTo(198, 38).SetMargins(0, 0, 0, 0);//166
            //MyBarCode.AddBarcodeValueTextBelowBarcode();
            //MyBarCode.SetMargins(100);
            //MyBarCode.
            MyBarCode.SaveAsHtmlFile("MyBarCode.html");
            // This line opens the image in your default image viewer
            //System.Diagnostics.Process.Start("MyBarCode.png");

        }

        private void Text1_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "pdf files (*.pdf)|*.pdf";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            Text1.Text=filePath;
        }

    }
}
      

