using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventBus
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AsyncHandlerAttribute : System.Attribute
    {
    }
}
