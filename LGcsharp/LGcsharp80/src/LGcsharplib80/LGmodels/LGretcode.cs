using System;
using System.Collections.Generic;
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
        Failed = -1,              // 操作失败，未知错误
        Success = 0,              // 操作成功
        EPERM = 1,                // 操作不允许
        ENOENT = 2,               // 文件或目录不存在
        EIO = 5,                  // I/O 错误
        ENOMEM = 12,              // 内存不足
        EACCES = 13,              // 权限不足
        EEXIST = 17,              // 文件已存在
        EINVAL = 22,              // 无效参数
        ENOSPC = 28,              // 磁盘空间不足
        ETIMEDOUT = 110,          // 连接超时
        ECONNREFUSED = 111,       // 连接被拒绝
        EHOSTUNREACH = 113,       // 主机不可达

        // ---------------- HTTP 错误码 ----------------
        HttpOk = 200,             // 请求成功
        HttpCreated = 201,        // 资源创建成功
        HttpBadRequest = 400,     // 请求参数错误
        HttpUnauthorized = 401,   // 未认证或认证失败
        HttpForbidden = 403,      // 无权限
        HttpNotFound = 404,       // 资源不存在
        HttpTimeout = 408,        // 请求超时
        HttpInternalError = 500,  // 服务器内部错误
        HttpBadGateway = 502,     // 网关错误
        HttpUnavailable = 503,    // 服务不可用
        HttpGatewayTimeout = 504, // 网关超时

        // ---------------- 数据库常见错误码 ----------------
        DbAccessDenied = 1045,    // 数据库用户名或密码错误
        DbUnknownDatabase = 1049, // 数据库不存在
        DbDuplicateEntry = 1062,  // 主键冲突
        DbTableNotExist = 1146,   // 表不存在
        DbDeadlock = 1213,        // 死锁检测
        DbCantConnect = 2002,     // 无法连接到数据库

        // ---------------- 网络通信常见错误码 ----------------
        NetConnectionReset = 10054,   // 远程主机强迫关闭连接
        NetHostUnreachable = 10065,   // 无法到达主机
        NetTimeout = 10060,       // 连接超时
        NetConnectionRefused = 10061, // 连接被拒绝
    }
}
