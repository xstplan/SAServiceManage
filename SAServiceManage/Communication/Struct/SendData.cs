using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SAServiceManage.Communication.Struct
{
    /// <summary>
    /// 发送数据
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    [System.Serializable]
    public struct SendData
    {
        /// <summary>
        /// 0正常模式 1复位 -404
        /// </summary>
        public short LIXRESET;
        /// <summary>
        /// 1.冻结 0.解冻
        /// </summary>
        public short LIXFREEZ;
        /// <summary>
        /// 数据
        /// </summary>
        public int SubjectType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public int[] Value;
    }
}
