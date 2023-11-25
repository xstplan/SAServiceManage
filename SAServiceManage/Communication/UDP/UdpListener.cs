using SAServiceManage.UDP.Communication;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAServiceManage.Communication.UDP
{
    public sealed class UdpListener : BaseUdpClient, IDisposable
    {

        public UdpListener(string ip = null, uint port = 11000) : base(ip, port)
        {

        }

        public event ReceiveEvent Received;

        private UdpClient _UdpClient;

        static UdpListener()
        {

        }
        private Thread _ListenThread;
        public override void Close()
        {
            IsOpen = false;
            _ListenThread?.Abort();
            _UdpClient?.Close();
        }
        public override void Open()
        {
            if (!CanOpen) return;
            IPAddress IpAddressRemte = IPAddress.Parse("127.0.0.1");

            _UdpClient = new UdpClient(new IPEndPoint(IpAddressRemte, (int)8889));
            _ListenThread = new Thread(StartLisening);
            _ListenThread.IsBackground = true;
            _ListenThread?.Start();

        }
        private void StartLisening()
        {

            try
            {


                IsOpen = true;
                do
                {
                    Buffer = _UdpClient.Receive(ref _IpEndPoinRemote);
                    Received?.Invoke(this, new SAServiceManage.UDP.Communication.ResolveEventArgs(Buffer, _IpEndPoinRemote));
                } while (IsOpen);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Close();
            }
        }

        #region GC
        private bool _Diposed = false;
        ~UdpListener()
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
