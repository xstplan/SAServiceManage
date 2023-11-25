using SAServiceManage.UDP.Communication;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SAServiceManage.Communication.UDP
{
    public class UdpSender : BaseUdpClient, IDisposable
    {
        private Socket _Socket;

        static UdpSender() { }


        public UdpSender(string ip = "127.0.0.1", uint port = 11000) : base(ip, port) { }

        public override void Close()
        {
            IsOpen = false;
            _Socket?.Close();
            _Socket = null;
        }

        public override void Open()
        {
            if (!CanOpen) return;

            try
            {

                _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                IsOpen = true;
            }
            catch (Exception ex)
            {

                Close();
                throw ex;
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="buff"></param>
        public void Send(IEnumerable<byte> buff)
        {
            if (!IsOpen) Open();

            if (buff.Any())
            {
                int length = buff.Count();
                Buffer = new byte[length];
                Array.Copy(buff.ToArray(), Buffer, length);
                length = _Socket.SendTo(Buffer, _IpEndPoinRemote);

            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg">UTF8编码的字符串</param>
        public void Send(string msg)
        {

            Send(Encoding.UTF8.GetBytes(msg));
        }

        #region GC
        private bool _Diposed = false;
        ~UdpSender()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_Diposed)
            {
                if (disposing)
                {
                    Close();
                }
                _Diposed = true;
            }
        }
        #endregion

    }
}
