using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.IO.Compression;
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
using System.Diagnostics;

namespace MemoProfessionalErrorTest
{
    /*

Xaml/Document.xaml
_rels/.rels
Xaml/Image1.gif
Xaml/_rels/Document.xaml.rels
Xaml/Image2.gif
Xaml/Image3.gif
Xaml/Image4.gif
Xaml/Image5.gif
Xaml/Image6.gif
Xaml/Image7.gif
Xaml/Image8.gif
Xaml/Image9.gif
Xaml/Image10.gif
Xaml/Image11.gif
Xaml/Image12.gif
Xaml/Image13.gif
Xaml/Image14.gif
Xaml/Image15.gif
Xaml/Image16.gif
Xaml/Image17.gif
Xaml/Image18.gif
Xaml/Image19.gif
[Content_Types].xml


    */
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();

            const string sourceDirectoryName = "source";
            const string fileName = "new_error";

            //ZipArchiveMode.Update 설정을 할 수 있도록 하기위해 FileAccess.ReadWrite로 변경
            using (Stream stream = new FileStream(
                $"{sourceDirectoryName}/_{fileName}.xaml", FileMode.Open, FileAccess.ReadWrite))
            {

                const string relationshipFile = "_rels/.rels";
                const string docFile = "Xaml/Document.xaml";
                const string docRelationshipFile = "Xaml/_rels/Document.xaml.rels";
                const string contentTypesFile = "[Content_Types].xml";

                ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Update, true, Encoding.UTF8);
                List<ZipArchiveEntry> entries = archive.Entries.ToList();

                // 기존 4가지 항목 제거
                entries.ForEach(x => Debug.WriteLine(x.FullName));
                entries.ForEach(x =>
                {
                    if (x.FullName == relationshipFile)
                        x.Delete();
                    else if (x.FullName == docRelationshipFile)
                        x.Delete();
                    else if (x.FullName == contentTypesFile)
                        x.Delete();
                    else if (x.FullName == docFile)
                        x.Delete();
                });

                // 새로 4가지 항목 추가
                archive.CreateEntryFromFile("error/" + Path.GetFileName(relationshipFile), relationshipFile);
                archive.CreateEntryFromFile("error/" + Path.GetFileName(docRelationshipFile), docRelationshipFile);
                archive.CreateEntryFromFile("error/" + Path.GetFileName(contentTypesFile), contentTypesFile);
                archive.CreateEntryFromFile("error/" + Path.GetFileName(docFile), docFile);
                archive.Dispose();
            }

            using (Stream stream = new FileStream($"{sourceDirectoryName}/_{fileName}.xaml", FileMode.Open, FileAccess.Read))
            {
                new TextRange(_richTextBox.Document.ContentStart, _richTextBox.Document.ContentEnd)
                    .Load(stream, System.Windows.DataFormats.XamlPackage);
            }
        }
    }
}
