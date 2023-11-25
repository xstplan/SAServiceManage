using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SAServiceManage.Tools.Converter
{
    public class BytesAsStruct
    {    /// <summary>
         /// 结构体转字节
         /// </summary>
         /// <param name="obj"></param>
         /// <returns></returns>
        public byte[] StructToBytes(object obj)
        {
            int size = Marshal.SizeOf(obj);
            byte[] bytes = new byte[size];
            IntPtr structPts = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(obj, structPts, false);
            Marshal.Copy(structPts, bytes, 0, size);
            Marshal.FreeHGlobal(structPts);
            return bytes;

        }

        /// <summary>
        /// 字节转结构体
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public object BytesToStruct(byte[] bytes, Type type)
        {
            int size = Marshal.SizeOf(type);
            if (size > bytes.Length) return null;
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            Marshal.Copy(bytes, 0, structPtr, size);
            object obj = Marshal.PtrToStructure(structPtr, type);
            Marshal.FreeHGlobal(structPtr);
            return obj;
        }
    }
}
