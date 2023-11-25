using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.IO;
using System.Diagnostics;
using System.Threading;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows;
using System.Text.RegularExpressions;

namespace SAServiceManage.ViewModel.Basic
{
    public class DefaultPageViewModel : ViewModelBase
    {
    

        //steamerrorreporter.exe目录
        private string SteamCMDPath = @"SteamCMD/steamerrorreporter.exe";
        // SteamCMD安装包
        private string SteamCMDInstallPath = @"SteamCMD/steamcmd.exe";

        //SteamCMD安装程序
        private Process SteamCMDProcess;
        //SteamCMD线程
        private Thread SteamCMDThread;
        //是否运行SteamCMD线程
        private bool IsSteamCMDThread = true;
        /// <summary>
        /// 是否已经安装SteamCMD
        /// </summary>
        private bool _IsInstallSteamCMD;

        public bool IsInstallSteamCMD
        {
            get { return _IsInstallSteamCMD; }
            set { Set(ref _IsInstallSteamCMD, value); }
        }

        private bool _IsStartButton = true;

        public bool IsStartButton
        {
            get { return _IsStartButton; }
            set { Set(ref _IsStartButton, value); }
        }


        /// <summary>
        /// Steam更新信息
        /// </summary>
        private string _UpdataContent;

        public string UpdataContent
        {
            get { return _UpdataContent; }
            set { Set(ref _UpdataContent, value); }
        }

        #region 安装SteamCMD Button程序
        public RelayCommand SteamInstallCmd => new RelayCommand(SteamInstall);

        /// <summary>
        /// 按钮信息
        /// </summary>
        private string _IsInstallSteamCMDButtonCotent = "安装SteamCMD";

        public string IsInstallSteamCMDButtonCotent
        {
            get { return _IsInstallSteamCMDButtonCotent; }
            set { Set(ref _IsInstallSteamCMDButtonCotent, value); }
        }

       
        #endregion

        #region 安装游戏CMD
  
 
     
      

        private bool _IsGameButton;
        /// <summary>
        /// 是否启动游戏安装按钮
        /// </summary>
        public bool IsGameButton
        {
            get { return _IsGameButton; }
            set { Set(ref _IsGameButton, value); }
        }
     
        private bool _IsFormal = true;
        /// <summary>
        /// 正式版
        /// </summary>
        public bool IsFormal
        {
            get { return _IsFormal; }
            set { Set(ref _IsFormal, value); }
        }


      
        #endregion

        /// <summary>
        /// Steam安装
        /// </summary>
        private void SteamInstall()
        {

            OpneSteamCMD();

        }
        private bool IsPath=true;
        /// <summary>
        /// 初始化
        /// </summary>
        public DefaultPageViewModel()
        {

            Messenger.Default.Register<bool>(this, "CloseSteamCMD", CloseSteamCMD);

           

            if (!File.Exists(SteamCMDPath))
            {
                string AppPath = Environment.CurrentDirectory;
                 IsPath = true;
                for (int i = 0; i < AppPath.Length; i++)
                {
                    //正则表达式逐个字符判断是否为汉字
                    if (Regex.IsMatch(AppPath[i].ToString(), @"[\u4e00-\u9fbb]+"))
                    {
                        IsPath = false;
                    }
                }
              
                UpdataContent = "SteamCMD未安装";
                if (IsPath) 
                {
                    if (HandyControl.Controls.MessageBox.Show("SteamCMD未安装,是否下载", "提示", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        IsInstallSteamCMD = false;
                        IsStartButton = false;
                        OpneSteamCMD();
                    }

                }
                else 
                {
                    HandyControl.Controls.MessageBox.Show("注意:软件安装目录不能包含中文路径", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                }
             

                
            }
            else
            {
               
                IsInstallSteamCMD = true;
                IsInstallSteamCMDButtonCotent = "更新SteamCMD";
                UpdataContent = "SteamCMD已安装";
            }

        }




        /// <summary>
        /// 打开cmd安装程序
        /// </summary>
        public void OpneSteamCMD()
        {
            if (IsPath)
            {
                if (IsInstallSteamCMD)
                {
                    UpdataContent = "SteamCMD更新中，这需要几分钟时间.....";
                }
                else
                {
                    UpdataContent = "SteamCMD安装中，这需要几分钟时间.....";
                }
                SteamCMDThread = new Thread(a =>
                {
                    try
                    {


                    //设置要启动的应用程序
                    SteamCMD();
                    // p.StandardInput.WriteLine("cd "+ SteamCMDInstallPath + "&exit");
                    //p.StandardInput.AutoFlush = true;
                    do
                        {
                            string strOuput = SteamCMDProcess.StandardOutput.ReadLine();
                            if (strOuput == null)
                            {
                                IsSteamCMDThread = true;
                                IsInstallSteamCMD = true;

                                UpdataContent = "取消，或网络异常";
                                CloseSteamCMD(true);
                                break;
                            }
                            if (strOuput == "Loading Steam API...OK")
                            {

                                IsSteamCMDThread = true;
                                IsInstallSteamCMD = true;
                                IsStartButton = true;
                                IsInstallSteamCMDButtonCotent = "更新SteamCMD";
                                UpdataContent = "SteamCMD安装成功";
                                CloseSteamCMD(true);

                                break;
                            }
                            UpdataContent = strOuput;

                        } while (IsSteamCMDThread);
                    //p.Close();
                }
                    catch (Exception)
                    {
                        HandyControl.Controls.Growl.Error("错误，检查是否丢失文件", "错误提示");


                    }
                });
                SteamCMDThread.IsBackground = true;
                SteamCMDThread.Start();
            }
            else 
            {
                HandyControl.Controls.MessageBox.Show("注意:软件安装目录不能包含中文路径", "提示", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }


        public void CloseSteamCMD(bool b)
        {
            KillProcess();
            IsSteamCMDThread = false;

            SteamCMDThread?.Abort();
            SteamCMDProcess?.Close();
        }
     
        /// <summary>
        /// 启动SteamCMD命令
        /// </summary>
        /// <returns></returns>
        public void SteamCMD()
        {
            try
            {


                SteamCMDProcess = new Process();
                SteamCMDProcess.StartInfo.FileName = SteamCMDInstallPath;
                //是否使用操作系统shell启动
                SteamCMDProcess.StartInfo.UseShellExecute = false;
                // 接受来自调用程序的输入信息
                SteamCMDProcess.StartInfo.RedirectStandardInput = true;
                //输出信息
                SteamCMDProcess.StartInfo.RedirectStandardOutput = true;
                // 输出错误
                SteamCMDProcess.StartInfo.RedirectStandardError = false;
                //不显示程序窗口
                SteamCMDProcess.StartInfo.CreateNoWindow = false;


                //启动程序
                SteamCMDProcess.Start();
            }
            catch (Exception)
            {
                UpdataContent = "SteamCMD丢失";

            }
        }

        public static void KillProcess()//关闭线程
        {
            foreach (Process p in Process.GetProcesses())//GetProcessesByName(strProcessesByName))
            {
                if (p.ProcessName.ToUpper().Contains("CMD"))
                {
                    try
                    {
                        p.Kill();
                        p.WaitForExit(); // possibly with a timeout
                    }
                    catch (Win32Exception e)
                    {
                        // process was terminating or can't be terminated - deal with it
                    }
                    catch (InvalidOperationException e)
                    {
                        // process has already exited - might be able to let this one go
                    }
                }
            }
        }
    }
}
