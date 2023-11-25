using SAServiceManage.Communication.Struct;
using SAServiceManage.Communication.UDP;
using SAServiceManage.Tools.Converter;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SAServiceManage.ViewModel.Communication
{
    public class UDPViewModel
    {
        /// <summary>
        /// UDP接受
        /// </summary>
        public UdpListener Listener { get; set; }

        /// <summary>
        /// UDP发送
        /// </summary>
        public UdpSender udpSender { get; set; }
        public UDPViewModel()
        {
            try
            {
                //发送数据
                Listener = new UdpListener();
                OpenUdp();
                #region 发送数据
                udpSender = new UdpSender();
                SendData sendData = new SendData();
                sendData.LIXFREEZ = 1;
                BytesAsStruct bytesAsStruct = new BytesAsStruct();
                udpSender.Send(bytesAsStruct.StructToBytes(sendData));
                #endregion


            }
            catch (Exception ex)
            {
                //netstat -ano|findstr 8889
                //taskkill  -F -PID 17600
                // Growl.ErrorGlobal("网络监听初始化错误");

            }

        }
        /// <summary>
        /// 打开UDP
        /// </summary>
        private void OpenUdp()
        {
            try
            {
                if (Listener.IsOpen)
                {
                    Listener.Close();

                }
                else
                {

                    Listener.Open();
                    Listener.Received += ResolveEvent;

                }
            }
            catch (Exception ex)
            {
                if (((System.Net.Sockets.SocketException)ex).ErrorCode == 10048)
                {

                    //端口被占用

                    Thread thread = new Thread(a =>
                    {

                        //设置要启动的应用程序
                        Process p = CMDtaskkill();
                        p.StandardInput.WriteLine("netstat -ano|findstr 8889" + "&exit");
                        p.StandardInput.AutoFlush = true;
                        string strOuput = p.StandardOutput.ReadToEnd();
                        p.Close();
                        string pid = "";
                        for (int i = strOuput.ToCharArray().Length; i != 0; i--)
                        {
                            if (strOuput.ToCharArray()[i - 1] != ' ')
                            {
                                pid = strOuput.ToCharArray()[i - 1] + pid;

                            }
                            else
                            {
                                break;
                            }
                        }
                        p = CMDtaskkill();

                        p.StandardInput.WriteLine("taskkill  -F -PID " + pid.Trim() + "&exit");
                        p.StandardInput.AutoFlush = true;
                        strOuput = p.StandardOutput.ReadToEnd();
                        p.Close();
                        ///"端口被占用,已执行端口释放,请重新打开软件";
                    });
                    thread.IsBackground = true;
                    thread.Start();
                }


            }
        }
        /// <summary>
        /// 启动CMD命令
        /// </summary>
        /// <returns></returns>
        public Process CMDtaskkill()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;
            //启动程序
            p.Start();
            return p;
        }
        /// <summary>
        /// UDP回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void ResolveEvent(object sender, SAServiceManage.UDP.Communication.ResolveEventArgs args)
        {

            //数据返回
            switch (args.receiveData.LXXFREEZE)
            {
                case 1:

                    Application.Current.Dispatcher.Invoke(() =>
                    {

                    });
                    break;

                case 2:

                    Application.Current.Dispatcher.Invoke(() =>
                    {

                    });
                    break;

                case 3:

                    Application.Current.Dispatcher.Invoke(() =>
                    {

                    });

                    break;
                default:
                    break;
            }

        }
    }
}
