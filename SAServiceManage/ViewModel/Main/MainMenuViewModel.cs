using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using HandyControl.Data;

using SAServiceManage.Tools.Helper;
using SAServiceManage.UserControls.Basic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAServiceManage.ViewModel.Main
{
    public class MainMenuViewModel : ViewModelBase
    {
        private object _BasicUserControl;
        public object BasicUserControl
        {
            get { return _BasicUserControl; }
            set { Set(ref _BasicUserControl, value); }
        }

        //  = new Environment_Settings();
        public RelayCommand<FunctionEventArgs<object>> SwitchItemCmd => new RelayCommand<FunctionEventArgs<object>>(SwitchItem);



        public RelayCommand<string> SelectCmd => new RelayCommand<string>(Select);

        private static string _HeaderTitle = "";
        public MainMenuViewModel()
        {
            Messenger.Default.Register<bool>(this, "NewContentMain", LeftMain);
            LeftMain(true);

        }
        private void LeftMain(bool b)
        {
            if (_HeaderTitle != "")
            {
                object obj = AssemblyHelper.CreateInternalInstance($"UserControls.Basic.{_HeaderTitle}");
                BasicUserControl = obj; ;

            }
            else
            {
                BasicUserControl = new DefaultPage();
            }

        }
        /// <summary>
        /// 菜单选择
        /// </summary>
        /// <param name="header"></param>
        private void Select(string header)
        {
            if (BasicUserControl is IDisposable disposable)
            {
                disposable.Dispose();
            }
            _HeaderTitle = header;
            object obj = AssemblyHelper.CreateInternalInstance($"UserControls.Basic.{header}");
            BasicUserControl = obj;
        }
        private void SwitchItem(FunctionEventArgs<object> info)
        {
            // Growl.Info((info.Info as SideMenuItem)?.Header.ToString());

        }
    }
}
