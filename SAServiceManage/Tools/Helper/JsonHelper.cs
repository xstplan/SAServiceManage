using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAServiceManage.Tools.Helper
{
    public class JsonHelper<T> where T : new()
    {

        /// <summary>
        /// 获取路径json
        /// </summary>
        /// <returns></returns>
        public static T GetPathJson(string path)
        {

            T dtList = JsonConvert.DeserializeObject<T>(File.ReadAllText(path + ".json"));
            return dtList;

        }
        /// <summary>
        /// 保存路径json
        /// </summary>
        /// <param name="value"></param>
        public static void SetThemeColor(string path, T obj)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(obj));
        }
    }
}
