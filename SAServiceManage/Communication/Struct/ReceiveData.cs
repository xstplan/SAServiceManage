using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SAServiceManage.Communication.Struct
{
    /// <summary>
    /// 接受数据
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    [System.Serializable]
    public struct ReceiveData
    {
        /// <summary>
        /// 0正常模式 1复位
        /// </summary>
        public short LXXRESET;
        /// <summary>
        /// 1.冻结 0.解冻
        /// </summary>
        public short LXXFREEZE;

        public float time;


    }
}
