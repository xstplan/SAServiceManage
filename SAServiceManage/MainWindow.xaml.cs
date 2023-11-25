using GalaSoft.MvvmLight.Messaging;

using SAServiceManage.UserControls.Main;

using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SAServiceManage
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            NonClientAreaContent = new NonClientAreaContent();
            ControlMain.Content = new MainWindowContent();
            Messenger.Default.Register<bool>(this, "NewMain", NewMain);

        }
        public void NewMain(bool b)
        {
            NonClientAreaContent = new NonClientAreaContent();
            ControlMain.Content = new MainWindowContent();

        }
        private void SideMenuItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Messenger.Default.Send(true, "1");
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (HandyControl.Controls.MessageBox.Show("是否关闭程序", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Messenger.Default.Send<bool>(true, "CloseSteamCMD");
                Environment.Exit(0);
                Process.GetCurrentProcess().Kill();
              
                Application.Current.Shutdown();

               
                base.OnClosing(e);

            }
            else
            {
                e.Cancel = true;
            }

        }
    }
}
