using GalaSoft.MvvmLight.Messaging;

using SAServiceManage.Tools.Helper;

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

namespace SAServiceManage.UserControls.Main
{
    /// <summary>
    /// NonClientAreaContent.xaml 的交互逻辑
    /// </summary>
    public partial class NonClientAreaContent
    {
        public NonClientAreaContent()
        {
            InitializeComponent();
        }
        private void ButtonConfig_OnClick(object sender, RoutedEventArgs e) => PopupConfig.IsOpen = true;
        private void ButtonLangs_OnClick(object sender, RoutedEventArgs e)
        {
            if ((e.OriginalSource as Button).Tag.Equals(AppConfigHelper.GetAppSettings("Langs")))
            {
                return;
            }
            else
            {
                AppConfigHelper.SaveAppSettings("Langs", (e.OriginalSource as Button).Tag.ToString());
                // ConfigHelper.Instance.SetLang((e.OriginalSource as Button).Tag.ToString());
                AppConfigHelper.Instance.SetLang((e.OriginalSource as Button).Tag.ToString());
                //刷新语言
                Messenger.Default.Send(true, "NewMain");
                Messenger.Default.Send(true, "NewContentMain");

            }
        }
    }
}
