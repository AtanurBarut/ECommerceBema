using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Intercepters
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        /// <summary>
        /// Method calışmadan once
        /// </summary>
        /// <param name="ınvocatin"></param>
        protected virtual void OnBefore(IInvocation invocation) { }

        /// <summary>
        /// Method calıştıktan sonra
        /// </summary>
        /// <param name="ınvocatin"></param>
        protected virtual void OnAfter(IInvocation invocation) { }

        /// <summary>
        /// Hata alındığında
        /// </summary>
        /// <param name="ınvocatin"></param>
        protected virtual void OnException(IInvocation invocation, Exception e) { }

        /// <summary>
        /// Sistem başarılı olduğunda
        /// </summary>
        /// <param name="ınvocatin"></param>
        protected virtual void OnSuccess(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed(); ///metodu calıştır
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
