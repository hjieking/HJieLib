using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace MiniApp
{
    /// <summary>
    /// 同一个HttpContext类型与不同服务器类型之间的适配问题也可可以通过添加一个抽象层来解决，我们定义在该层的对象称为Feature
    /// </summary>
    public interface IHttpRequestFeature
    {
        Uri Url { get; }
        NameValueCollection Headers { get; }
        Stream Body { get; }
    }
}
