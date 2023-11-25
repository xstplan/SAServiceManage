using HandyControl.Controls;

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

namespace SAServiceManage.UserControls.Basic
{
    /// <summary>
    /// help.xaml 的交互逻辑
    /// </summary>
    public partial class help : UserControl
    {
        public help()
        {
            InitializeComponent();
        }

        private void linkHelp_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://qm.qq.com/cgi-bin/qm/qr?k=UeVd-j7fZQVuZF_keutHvBjpi-od3l-8&jump_from=webapi"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var d = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                Process.Start(new ProcessStartInfo(d+"/FactoryGame/Saved/SaveGames/server"));
            }
            catch (Exception)
            {

                HandyControl.Controls.MessageBox.Error("异常错误,没有获取到服务器存档");
            }
           
        }

        private void Severt_WWW_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://satisfactory.fandom.com/wiki/Dedicated_servers"));
        }

        private void My_Click(object sender, RoutedEventArgs e)
        {

            About about = new About();

            about.Show();



        }
    }
}
