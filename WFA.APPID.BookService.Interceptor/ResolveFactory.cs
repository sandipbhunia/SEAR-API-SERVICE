using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.Interceptors.TypeInterceptors.VirtualMethodInterception;
using Unity.Interception.PolicyInjection;
using Unity.Interception.PolicyInjection.Policies;

namespace WFA.APPID.BookService.Interceptor
{
    public class ResolveFactory
    {
        public static T Get<T>(object[] paramArray) where T : class
        {

            VirtualMethodInterceptor interceptor = new VirtualMethodInterceptor();
            CurrentInterceptionRequest request = new CurrentInterceptionRequest(interceptor, typeof(T), typeof(T));
            InjectionPolicy[] policies = new InjectionPolicy[] { new AttributeDrivenPolicy() };
            PolicyInjectionBehavior behaviour = new PolicyInjectionBehavior(request, policies, null);
            return Intercept.NewInstance<T>(
                interceptor, new IInterceptionBehavior[] { behaviour },
                paramArray);
        }
    }
}
