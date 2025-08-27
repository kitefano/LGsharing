using LGcsharplib80.LGcommons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LGcsharplib80.LGmodels
{
    /// <summary>
    /// 类和json、结构体和json 转换
    /// 正常情况下直接使用System.Text.Json的Serialize和Deserialize就行，这里就是加了个json选项JsonSerializerOptions
    /// </summary>
    public class LGjson
    {
        #region 定义JSON序列化选项
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            // 是否格式化输出: 是否在json字符串中添加换行符和缩进
            WriteIndented = false,
            // 不转义特殊字符
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            // 是否序列化和反序列化字段, 默认是false不序列化。
            IncludeFields = false,
        };
        #endregion

        #region json序列化（支持 class、struct与json直接的转换） 
        // 序列化（支持 class 和 struct）
        // 注意：如果传入的对象为 null，则返回的 JSON 字符串为 "null"
        public static LGresult<string> Serialize<T>(T obj, JsonSerializerOptions? options = null)
        {
            LGresult<string> lgret = new();
            // 参数检查
            if (obj == null)
            {
                lgret.Code = 100;
                lgret.Message = $"{LGcom.GetCallerInfo()},  传入的对象obj为null。";
                return lgret;
            }
            options ??= _jsonSerializerOptions;

            string json = JsonSerializer.Serialize(obj, options);
            lgret.Code = 0;
            lgret.Message = $"{LGcom.GetCallerInfo()}, 序列化成功。";
            lgret.Data = json;
            return lgret;
        }

        #endregion

        #region json反序列化（支持 class、struct与json直接的转换）
        // 反序列化（支持 class 和 struct）
        // 注意：如果传入的 JSON 字符串为 "null" 或者空字符串，则返回的对象为 null
        public static LGresult<T> Deserialize<T>(string json, JsonSerializerOptions? options = null)
        {
            LGresult<T> lgret = new();
            // 参数检查: 参数除了"null",其他情况不用检查，因为JsonSerializer会处理参数不正确的情况。
            if (json == "null")
            {
                lgret.Code = 100;
                lgret.Message = $"{LGcom.GetCallerInfo()}, 传入的json字符串为\"null\"。";
                lgret.Data = default; // 返回默认值
                return lgret;
            }
            options ??= _jsonSerializerOptions;

            T? obj = JsonSerializer.Deserialize<T>(json, options);
            lgret.Code = 0;
            lgret.Message = $"{LGcom.GetCallerInfo()}, 反序列化成功。";
            lgret.Data = obj;
            return lgret;
        }
        #endregion
    }
}
