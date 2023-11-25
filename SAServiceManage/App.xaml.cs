using HandyControl.Tools;

using SAServiceManage.Tools.Helper;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SAServiceManage
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        [SuppressMessage("ReSharper", "NotAccessedField.Local")]
        private static Mutex AppMutex;
        protected override void OnStartup(StartupEventArgs e)
        {
            AppMutex = new Mutex(true, "SAServiceManage", out var createdNew);

            if (!createdNew)
            {
                var current = Process.GetCurrentProcess();

                foreach (var process in Process.GetProcessesByName(current.ProcessName))
                {
                    if (process.Id != current.Id)
                    {
                        if (process.MainModule.FileName == process.MainModule.FileName)
                            HandyControl.Controls.MessageBox.Show("程序已经在运行中", "程序已经在运行中", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Environment.Exit(0);
                        Win32Helper.SetForegroundWindow(process.MainWindowHandle);
                        break;
                    }
                }
                Shutdown();
            }
            else
            {
                //初始化操作
                var splashScreen = new SplashScreen("Resources/Img/Cover.png");
                splashScreen.Show(true);
                //splashScreen.Close(new TimeSpan(0, 0, 10));
                base.OnStartup(e);
                string langs = AppConfigHelper.GetAppSettings("Langs");
                ConfigHelper.Instance.SetWindowDefaultStyle();
                ConfigHelper.Instance.SetNavigationWindowDefaultStyle();
                //ConfigHelper.Instance.SetLang(langs);
                AppConfigHelper.Instance.SetLang(langs);
                ShutdownMode = ShutdownMode.OnMainWindowClose;


            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

        }
        private void UpdateRegistry()
        {
            var processModule = Process.GetCurrentProcess().MainModule;
            if (processModule != null)
            {
                var registryFilePath = $"{Path.GetDirectoryName(processModule.FileName)}\\Registry.reg";
                if (!File.Exists(registryFilePath))
                {
                    var streamResourceInfo = GetResourceStream(new Uri("pack://application:,,,/Resources/Registry.txt"));
                    if (streamResourceInfo != null)
                    {
                        StreamReader streamReader = new StreamReader(streamResourceInfo.Stream);
                        var reader = streamReader;
                        var registryStr = reader.ReadToEnd();
                        var newRegistryStr = registryStr.Replace("#", processModule.FileName.Replace("\\", "\\\\"));
                        File.WriteAllText(registryFilePath, newRegistryStr);
                        Process.Start(new ProcessStartInfo("cmd", $"/c {registryFilePath}")
                        {
                            UseShellExecute = false,
                            CreateNoWindow = true
                        });
                    }
                }
            }
        }
    }
}
