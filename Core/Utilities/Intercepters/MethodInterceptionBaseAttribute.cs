using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Intercepters
{
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public virtual void Intercept(IInvocation invocation)
        {
        }
    }
}
