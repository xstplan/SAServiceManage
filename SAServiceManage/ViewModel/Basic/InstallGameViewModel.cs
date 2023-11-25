using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using SAServiceManage.Tools.Helper;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAServiceManage.ViewModel.Basic
{
    public class InstallGameViewModel :ViewModelBase
    {



        //服务器安装目录
        private string Path = @"SteamCMD/WindowService";


        private bool _IsStartButton = true;

        public bool IsStartButton
        {
            get { return _IsStartButton; }
            set { Set(ref _IsStartButton, value); }
        }

        private bool _IsGame;

        public bool IsGame
        {
            get { return _IsGame; }
            set { Set(ref _IsGame, value); }
        }

        //按钮
        private string _IsInstallGameButtonCotent = "安装游戏服务器";
        public string IsInstallGameButtonCotent
        {
            get { return _IsInstallGameButtonCotent; }
            set { Set(ref _IsInstallGameButtonCotent, value); }
        }

        private bool _IsBeta;
        /// <summary>
        /// 测试版
        /// </summary>
        public bool IsBeta
        {
            get { return _IsBeta; }
            set { Set(ref _IsBeta, value); }
        }
        //文字
        private string _GameContent = "安装游戏服务器";

        public string GameContent
        {
            get { return _GameContent; }
            set { Set(ref _GameContent, value); }
        }
        public InstallGameViewModel() 
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
                IsGame = false;
                IsInstallGameButtonCotent = "安装服务器";
                GameContent = "服务器未安装";
            }

            else if (!File.Exists(Path + "/FactoryServer.exe"))
            {
                IsInstallGameButtonCotent = "安装服务器";
                GameContent = "服务器未安装";
                IsGame = false;
            }
            else
            {
                GameContent = "服务器已安装";
                IsInstallGameButtonCotent = "更新服务器";
                IsGame = true;
            }

        }

        public RelayCommand InstallGameCmd => new RelayCommand(GameInstall);
        private bool IsGameSteamCMDThread = true;
        //SteamCMD游戏线程
        private Thread SteamGameCMDThread;
        /// <summary>
        /// 安装游戏服务器
        /// </summary>
        private void GameInstall()
        {

            SteamGameCMDThread = new Thread(a =>
            {
                try
                {
                    IsStartButton = false;
                    //设置要启动的应用程序
                    
                    Process p = CMDHelper.CMDtaskkill();
                    string EXEPath = Environment.CurrentDirectory;
                    string Di = EXEPath.Substring(0, EXEPath.IndexOf(":") + 1);

                    p.Start();

                    p.StandardInput.WriteLine(Di);
                    p.StandardInput.WriteLine(EXEPath);
                    p.StandardInput.WriteLine("cd SteamCMD");
                    //p.StandardInput.WriteLine("steamcmd.exe");

                    //p.StandardInput.WriteLine("force_install_dir WindowService");
                    //p.StandardInput.WriteLine("login anonymous");
                    p.StandardInput.WriteLine(InstallationGameField());

                    p.StandardInput.WriteLine("exit");
                    p.StandardInput.AutoFlush = true;

                    p.OutputDataReceived += GameInstallCMDReceived;

                    p.BeginOutputReadLine();

                    p.WaitForExit();
                    p.Close();
                    //do
                    //{
                    //    GameContent = p.StandardOutput.ReadLine();
                    //    if (GameContent == null) 
                    //    {
                    //        IsGameSteamCMDThread = false;

                    //    }
                    //    if (GameContent == "") 
                    //    {
                    //        GameContent = "这需要一段时间，请稍等....";
                    //    }

                    //} while (IsGameSteamCMDThread);



                    //p.StandardInput.AutoFlush = true;

                    //p.Close();
                }
                catch (Exception)
                {
                    HandyControl.Controls.Growl.Error("错误，检查是否丢失文件", "错误提示");


                }
            });
            SteamGameCMDThread.IsBackground = true;
            SteamGameCMDThread.Start();

        }
        private string InstallationGameField()
        {
            string IsBetaField = "";
            if (IsBeta == true)
            {
                IsBetaField = "-beta Experimental";
            }
            else
            {
                IsBetaField = "-beta public";
            }

            string o = "steamcmd.exe +force_install_dir WindowService +login anonymous +app_update 1690800 " + IsBetaField + " validate +quit";

            return o;
        }

        /// <summary>
        /// 游戏安装CMD事件
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        public void GameInstallCMDReceived(object o, DataReceivedEventArgs e)
        {
            GameContent = e.Data;
            if (e.Data == null)
            {
                IsGameSteamCMDThread = false;
                GameContent = "安装完成";
                IsStartButton = true;
                IsInstallGameButtonCotent = "更新服务器";
            }
            if (GameContent == "")
            {
                GameContent = "这需要一段时间，请稍等....";
                //Process p= (Process)o ;

            }


        }
    }
}
