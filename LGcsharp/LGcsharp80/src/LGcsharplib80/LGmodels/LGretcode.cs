using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGcsharplib80.LGmodels
{
    /// <summary>
    /// 常见错误码枚举
    /// 用于统一管理和快速查找常见错误码
    /// </summary>
    public enum LGretcode
    {
        // ---------------- 操作系统/通用错误码 ----------------
        [Description("操作失败，未知错误")]
        Failed = -1,              // 操作失败，未知错误
        [Description("操作成功")]
        Success = 0,              // 操作成功
        [Description("操作不允许")]
        EPERM = 1,                // 操作不允许
        [Description("文件或目录不存在")]
        ENOENT = 2,               // 文件或目录不存在
        [Description("I/O 错误")]
        EIO = 5,                  // I/O 错误
        [Description("内存不足")]
        ENOMEM = 12,              // 内存不足
        [Description("权限不足")]
        EACCES = 13,              // 权限不足
        [Description("文件已存在")]
        EEXIST = 17,              // 文件已存在
        [Description("无效参数")]
        EINVAL = 22,              // 无效参数
        [Description("磁盘空间不足")]
        ENOSPC = 28,              // 磁盘空间不足
        [Description("连接超时")]
        ETIMEDOUT = 110,          // 连接超时
        [Description("连接被拒绝")]
        ECONNREFUSED = 111,       // 连接被拒绝
        [Description("主机不可达")]
        EHOSTUNREACH = 113,       // 主机不可达
        [Description("网络不可达")]
        ENETUNREACH = 114,        // 网络不可达

        // ---------------- HTTP 错误码 ----------------
        [Description("请求成功")]
        HttpOk = 200,             // 请求成功
        [Description("资源创建成功")]
        HttpCreated = 201,        // 资源创建成功
        [Description("请求参数错误")]
        HttpBadRequest = 400,     // 请求参数错误
        [Description("未认证或认证失败")]
        HttpUnauthorized = 401,   // 未认证或认证失败
        [Description("无权限")]
        HttpForbidden = 403,      // 无权限
        [Description("资源不存在")]
        HttpNotFound = 404,       // 资源不存在
        [Description("请求超时")]
        HttpTimeout = 408,        // 请求超时
        [Description("服务器内部错误")]
        HttpInternalError = 500,  // 服务器内部错误
        [Description("网关错误")]
        HttpBadGateway = 502,     // 网关错误
        [Description("服务不可用")]
        HttpUnavailable = 503,    // 服务不可用
        [Description("网关超时")]
        HttpGatewayTimeout = 504, // 网关超时

        // ---------------- 数据库常见错误码 ----------------
        [Description("数据库访问被拒绝")]
        DbAccessDenied = 1045,    // 数据库用户名或密码错误
        [Description("数据库不存在")]
        DbUnknownDatabase = 1049, // 数据库不存在
        [Description("主键冲突")]
        DbDuplicateEntry = 1062,  // 主键冲突
        [Description("表不存在")]
        DbTableNotExist = 1146,   // 表不存在
        [Description("死锁检测")]
        DbDeadlock = 1213,        // 死锁检测
        [Description("无法连接到数据库")]
        DbCantConnect = 2002,     // 无法连接到数据库
        [Description("数据库连接超时")]
        DbTimeout = 2013,         // 数据库连接超时

        // ---------------- 网络通信常见错误码 ----------------
        [Description("网络连接重置")]
        NetConnectionReset = 10054,   // 远程主机强迫关闭连接
        [Description("主机不可达")]
        NetHostUnreachable = 10065,   // 无法到达主机
        [Description("连接超时")]
        NetTimeout = 10060,       // 连接超时
        [Description("连接被拒绝")]
        NetConnectionRefused = 10061, // 连接被拒绝
    }

    /// <summary>
    /// 错误码LGretcode工具类
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// LGretcode的扩展方法：获取枚举值上的 DescriptionAttribute 中文描述
        /// </summary>
        public static string GetMessage(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault();
            return attribute?.Description ?? "未知错误码";
        }
    }
}
