using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace PresentationCore.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string runtimeAssemblyLocation = typeof(TextBox).Assembly.Location;
            _textBlockRuntimeVersion.Text = 
                $"런타임 버전 : {FileVersionInfo.GetVersionInfo(runtimeAssemblyLocation).ProductVersion}";
            _textBlockAssemblyPath.Text = $"typeof(TextBox) 어셈블리 경로 : {runtimeAssemblyLocation}";
            MessageBox.Show($"짱도가 추가한 변수 : {Clipboard.Number}");
        }
    }
}
