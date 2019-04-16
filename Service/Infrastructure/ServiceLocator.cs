using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFoodApp.Service.Infrastructure
{
    public class ServiceLocator
    {
        private static IKernel _kernel;
        public static void Initialize(IKernel kernel)
        {
            _kernel = kernel;
        }
        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }
        public static object Get(Type type)
        {
            return _kernel.Get(type);
        }

        internal static T1 Get<T1>(params Ninject.Parameters.ConstructorArgument[] constructorArguments)
        {
            return _kernel.Get<T1>(constructorArguments);
        }
    }
}
