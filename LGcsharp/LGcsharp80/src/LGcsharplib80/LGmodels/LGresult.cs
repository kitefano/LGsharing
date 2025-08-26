using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGcsharplib80.LGmodels
{
    public class LGresult<T>
    {
        public int Code { get; set; } = -1;
        public string Message { get; set; } = string.Empty;
        // LGresult<T>作为函数返回时，要判断Data是否为空。
        public T? Data { get; set; } = default;
        public LGresult()
        {
        }
        public LGresult(int code, string message, T? data = default)
        {
            Code = code;
            Message = message;
            Data = data;
        }
        // 封装设置Data的方法，这里会对Data为空的情况进行处理。
        public void SetData(T? data)
        {
            if (data == null)
            {
                throw new Exception("LGresult<T>: 传入的值data为空。");
            }
            Data = data;
        }
        // 封装获取Data的方法，这里会对Data为空的情况进行处理。
        public T GetData()
        {
            if (Data == null)
            {
                throw new Exception("LGresult<T>: Data is null.");
            }
            return Data;
        }
    }
}
