using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using SAServiceManage.Tools.Helper;

namespace SAServiceManage.ViewModel.Basic
{
    public class ServiceStartViewModel : ViewModelBase
    {

        #region 启动参数
        private string _multihome = "";
        /// <summary>
        /// IP 地址
        /// </summary>
        public string multihome
        {
            get { return _multihome; }
            set { Set(ref _multihome, value); }
        }


        private string _ServerQueryPort = "";
        /// <summary>
        /// 查询端口15777
        /// </summary>
        public string ServerQueryPort
        {
            get { return _ServerQueryPort; }
            set { Set(ref _ServerQueryPort, value); }
        }


        private string _BeaconPort = "";
        /// <summary>
        /// 信标端口15000
        /// </summary>
        public string BeaconPort
        {
            get { return _BeaconPort; }
            set { Set(ref _BeaconPort, value); }
        }


        private string _Port = "";
        /// <summary>
        /// 7777
        /// </summary>
        public string Port
        {
            get { return _Port; }
            set { Set(ref _Port, value); }
        }


        #endregion

        private bool _IsStartButton = true;
        /// <summary>
        /// 是否启动游戏按钮
        /// </summary>
        public bool IsStartButton
        {
            get { return _IsStartButton; }
            set { Set(ref _IsStartButton, value); }
        }

        private bool _IsServerDete = false;
        /// <summary>
        /// 是否自启
        /// </summary>
        public bool IsServerDete
        {
            get { return _IsServerDete; }
            set { Set(ref _IsServerDete, value); }
        }

        private string _StartButtonContent;
        /// <summary>
        /// 启动游戏按钮文字
        /// </summary>
        public string StartButtonContent
        {
            get { return _StartButtonContent; }
            set { Set(ref _StartButtonContent, value); }
        }

        private bool IsKill = true;
        public ServiceStartViewModel()
        {
            multihome = AppConfigHelper.GetAppSettings("multihome");
            ServerQueryPort = AppConfigHelper.GetAppSettings("ServerQueryPort");
            BeaconPort = AppConfigHelper.GetAppSettings("BeaconPort");
            Port = AppConfigHelper.GetAppSettings("Port");
            if (IsStartButton)
            {
                StartButtonContent = "启动服务器";
            }


        }
        public RelayCommand StartButton => new RelayCommand(StartService);
        Process p;
        private bool NormalExit = true;
        Thread thread;
        /// <summary>
        /// 启动服务器
        /// </summary>
        public async void StartService()
        {
            try
            {
                AppConfigHelper.SaveAppSettings("multihome", multihome.ToString());
                AppConfigHelper.SaveAppSettings("ServerQueryPort", ServerQueryPort.ToString());
                AppConfigHelper.SaveAppSettings("BeaconPort", BeaconPort.ToString());
                AppConfigHelper.SaveAppSettings("Port", Port.ToString());
                if (IsStartButton)
                {
                    thread?.Abort();
                    thread = null;

                    IsStartButton = false;
                    StartButtonContent = "关闭服务器";
                   
                    //自动启动
                    string IsStart = AppConfigHelper.GetAppSettings("IsStart");
                    if (IsServerDete && IsStart == "1")
                    {
                        NormalExit = true;
                        ServerDetection();
                    }
                    else
                    {
                        if (IsStart == "1")
                        {
                            IsServerDete = false;
                        }
                        await OpenService();
                    }
                }
                else
                {
                    if (HandyControl.Controls.MessageBox.Show("停止服务器?", "提示", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {


                        Process[] processs = Process.GetProcessesByName("UE4Server-Win64-Shipping");
                        p.Close();
                        foreach (var item in processs)
                        {
                            item.Kill();
                        }

                        IsStartButton = true;
                        StartButtonContent = "开启服务器";
                        NormalExit = false;
                    }
                }


                thread = new Thread(a =>
                {
                    Thread.Sleep(2000);
                    Process process = new Process();

                    while (true)
                    {
                        Thread.Sleep(1000);
                        Process process_name = Process.GetCurrentProcess();
                        Process[] processs = Process.GetProcessesByName("UE4Server-Win64-Shipping");
                        if (processs.Length == 0)
                        {
                            IsKill = false;
                            IsStartButton = true;
                            StartButtonContent = "开启服务器";

                        }

                    }


                });
                thread.IsBackground = true;
                thread.Start();

            }
            catch (Exception)
            {

                HandyControl.Controls.MessageBox.Show("运行,请保证完整安装游戏服务器", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// 自启动
        /// </summary>
        public void ServerDetection()
        {
            Thread thread = new Thread(async a =>
            {

                Process process = new Process();
                while (NormalExit)
                {

                    Process process_name = Process.GetCurrentProcess();
                    Process[] processs = Process.GetProcessesByName("UE4Server-Win64-Shipping");
                    if (processs.Length == 0)
                    {
                        IsStartButton = false;
                        StartButtonContent = "关闭服务器";
                        await OpenService();

                    }
                    Thread.Sleep(1000);
                }

            });
            thread.IsBackground = true;
            thread.Start();

        }

        public async Task OpenService()
        {

            p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = false;
            // 输出错误
            p.StartInfo.RedirectStandardError = false;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;

            string EXEPath = Environment.CurrentDirectory;
            string Di = EXEPath.Substring(0, EXEPath.IndexOf(":") + 1);
            p.Start();
            p.StandardInput.WriteLine(Di);
            p.StandardInput.WriteLine(EXEPath);
            p.StandardInput.WriteLine("cd SteamCMD/WindowService");



            p.StandardInput.WriteLine("FactoryServer.exe -log -unattended" + CommandLineOptions());

            p.StandardInput.WriteLine("exit");

            p.StandardInput.AutoFlush = true;
            AppConfigHelper.SaveAppSettings("IsStart", "1");

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();


        }
        public string CommandLineOptions()
        {
            string src = "";
            if (multihome.Trim() != "")
            {
                src += " -multihome=" + multihome;
            }
            if (ServerQueryPort.Trim() != "")
            {
                src += " -ServerQueryPort=" + ServerQueryPort;
            }

            if (BeaconPort.Trim() != "")
            {
                src += " -BeaconPort=" + BeaconPort;
            }
            if (Port.Trim() != "")
            {
                src += " -Port=" + Port;
            }
            return src;

        }

    }
}
