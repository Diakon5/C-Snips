using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public static class Bootstrapper
    {
        public static void RegisterLazySingleton<I,T>(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver) where T : I, new()
        {
            
            services.RegisterLazySingleton<I>(() => new T());  // Call services.Register<i> and pass it lambda that creates instance of your service. T must implement I
        }
    }

}
