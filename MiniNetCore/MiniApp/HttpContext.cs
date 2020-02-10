using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniApp
{
    /// <summary>
    /// 请求和想要上下文对象
    /// </summary>
    public class HttpContext
    {
        /// <summary>
        /// 请求属性
        /// </summary>
        public HttpRequest Request { get; }
        /// <summary>
        /// 响应属性
        /// </summary>
        public HttpResponse Response { get; }

        public HttpContext(IFeatureCollection features)
        {
            Request = new HttpRequest(features);
            Response = new HttpResponse(features);
        }
    }
    public static partial class Extensions
    {
        public static Task WriteAsync(this HttpResponse response, string contents)
        {
            var buffer = Encoding.UTF8.GetBytes(contents);
            return response.Body.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}
