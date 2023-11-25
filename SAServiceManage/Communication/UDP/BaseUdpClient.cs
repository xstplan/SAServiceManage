using GalaSoft.MvvmLight;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SAServiceManage.UDP.Communication
{
    public abstract class BaseUdpClient : ViewModelBase
    {
        /// <summary>
        /// 端口
        /// </summary>
        protected uint _PortRemote;

        /// <summary>
        /// 端口
        /// </summary>
        public uint PortRemote
        {
            get { return _PortRemote; }
            set
            {
                if (IsOpen) return;
                Set(ref _PortRemote, value);

            }

        }

        /// <summary>
        /// 本地ip
        /// </summary>
        private string _IpLocal;
        /// <summary>
        /// 本地ip
        /// </summary>
        public string IpLocal
        {
            get { return _IpLocal; }
            protected set
            {
                Set(ref _IpLocal, value);

            }
        }


        /// <summary>
        /// IP
        /// </summary>
        protected IPAddress _IpAddressRemte;

        /// <summary>
        /// 远程端口
        /// </summary>
        protected IPEndPoint _IpEndPoinRemote = new IPEndPoint(IPAddress.Parse("127.0.0.1"), (int)8890);

        /// <summary>
        /// IP地址,接收器置null时监听所有IP,默认127.0.0.1
        /// </summary>
        protected string _IpRemote = string.Empty;

        public string IpRemote
        {

            get { return _IpRemote; }

            set
            {

                if (IsOpen) return;
                if (string.IsNullOrEmpty(value))
                {
                    _IpAddressRemte = IPAddress.Any;
                    Set(ref _IpRemote, IPAddress.Any.ToString());
                }
                else
                {
                    IPAddress address;
                    if (IPAddress.TryParse(value, out address))
                    {
                        _IpAddressRemte = address;
                        Set(ref _IpRemote, address.ToString());

                    }
                    else
                    {
                        _IpAddressRemte = null;
                        Set(ref _IpRemote, value);

                    }

                }
            }
        }
        /// <summary>
        /// 打开标识
        /// </summary>
        protected bool _IsOpen;
        public bool IsOpen
        {
            get { return _IsOpen; }
            protected set { Set(ref _IsOpen, value); }
        }
        /// <summary>
        /// 可以打开标记
        /// </summary>
        public bool CanOpen => _IpAddressRemte != null && !IsOpen;

        private byte[] _Buffer;

        /// <summary>
        /// 缓冲
        /// </summary>
        public byte[] Buffer
        {
            get { return _Buffer; }
            set { Set(ref _Buffer, value); }

        }
        public BaseUdpClient(string ip, uint port)
        {
            IpRemote = ip;
            PortRemote = port;
            var hostName = Dns.GetHostName();
            var address = Dns.GetHostEntry(hostName).AddressList.Where(a => a.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();

            IpLocal = address.ToString();

        }


        /// <summary>
        /// 打开接受发送功能
        /// </summary>
        public abstract void Open();

        /// <summary>
        /// 关闭接受发送功能
        /// </summary>
        public abstract void Close();


    }
}
