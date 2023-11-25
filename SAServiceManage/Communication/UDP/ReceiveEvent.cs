using SAServiceManage.Communication.Struct;
using SAServiceManage.Tools.Converter;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SAServiceManage.UDP.Communication
{
    public delegate void ReceiveEvent(object sender, ResolveEventArgs args);
    public class ResolveEventArgs
    {
        public byte[] Buffer { get; }

        public string Message { get; }

        public string Ip { get; } = string.Empty;

        public string Port { get; } = string.Empty;

        public ReceiveData receiveData { get; }

        public ResolveEventArgs(byte[] buffer, IPEndPoint endPoint)
        {
            Buffer = buffer;
            Message = Encoding.ASCII.GetString(Buffer);
            Ip = endPoint.Address.ToString();
            Port = endPoint.Port.ToString();
            BytesAsStruct bytesAsStruct = new BytesAsStruct();
            receiveData = (ReceiveData)bytesAsStruct.BytesToStruct(buffer, typeof(ReceiveData));
        }

    }
}
