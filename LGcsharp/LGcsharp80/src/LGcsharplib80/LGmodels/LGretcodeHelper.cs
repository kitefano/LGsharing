using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGcsharplib80.LGmodels
{
    /// <summary>
    /// 错误码LGretcode工具类
    /// </summary>
    public static class LGretcodeHelper
    {
        /// <summary>
        /// 错误码 -> 中文描述 映射表
        /// </summary>
        private static readonly Dictionary<int, string> CodeDescriptions = new()
        {
            // ---------------- 操作系统/通用错误码 ----------------
            { (int)LGretcode.Failed, "操作失败，未知错误" },
            { (int)LGretcode.Success, "操作成功" },
            { (int)LGretcode.EPERM, "操作不允许" },
            { (int)LGretcode.ENOENT, "文件或目录不存在" },
            { (int)LGretcode.EIO, "I/O 错误" },
            { (int)LGretcode.ENOMEM, "内存不足" },
            { (int)LGretcode.EACCES, "权限不足" },
            { (int)LGretcode.EEXIST, "文件已存在" },
            { (int)LGretcode.EINVAL, "无效参数" },
            { (int)LGretcode.ENOSPC, "磁盘空间不足" },
            { (int)LGretcode.ETIMEDOUT, "连接超时" },
            { (int)LGretcode.ECONNREFUSED, "连接被拒绝" },
            { (int)LGretcode.EHOSTUNREACH, "主机不可达" },
            // ---------------- HTTP 错误码 ----------------
            { (int)LGretcode.HttpOk, "请求成功" },
            { (int)LGretcode.HttpCreated, "资源创建成功" },
            { (int)LGretcode.HttpBadRequest, "请求参数错误" },
            { (int)LGretcode.HttpUnauthorized, "未认证或认证失败" },
            { (int)LGretcode.HttpForbidden, "无权限" },
            { (int)LGretcode.HttpNotFound, "资源不存在" },
            { (int)LGretcode.HttpTimeout, "请求超时" },
            { (int)LGretcode.HttpInternalError, "服务器内部错误" },
            { (int)LGretcode.HttpBadGateway, "网关错误" },
            { (int)LGretcode.HttpUnavailable, "服务不可用" },
            { (int)LGretcode.HttpGatewayTimeout, "网关超时" },
            // ---------------- 数据库常见错误码 ----------------
            { (int)LGretcode.DbAccessDenied, "数据库用户名或密码错误" },
            { (int)LGretcode.DbUnknownDatabase, "数据库不存在" },
            { (int)LGretcode.DbDuplicateEntry, "主键冲突" },
            { (int)LGretcode.DbTableNotExist, "表不存在" },
            { (int)LGretcode.DbDeadlock, "死锁检测" },
            { (int)LGretcode.DbCantConnect, "无法连接到数据库" },
            // ---------------- 网络通信常见错误码 ----------------
            { (int)LGretcode.NetTimeout, "网络连接超时" },
            { (int)LGretcode.NetConnectionRefused, "网络连接被拒绝" },
            { (int)LGretcode.NetConnectionReset, "远程主机强迫关闭连接" },
            { (int)LGretcode.NetHostUnreachable, "无法到达主机" }
        };

        /// <summary>
        /// 根据错误码获取中文描述
        /// </summary>
        public static string GetMessage(int code)
        {
            return CodeDescriptions.TryGetValue(code, out var message)
                ? $"{(LGretcode)code}-{message}" ?? "未知错误码"
                : "未知错误码";
        }
    }
}
