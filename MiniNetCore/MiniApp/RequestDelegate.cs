using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniApp
{
    /// <summary>
    /// HttpHandler表示是通过这个委托对象来表示
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public delegate Task RequestDelegate(HttpContext context);
}
