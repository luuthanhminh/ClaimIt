using System;
using System.Threading.Tasks;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using ClaimIt.Core.ViewModels;

namespace ClaimIt.UI
{
    public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<FirstViewModel>();
        }

        /// <summary>
        /// Do any UI bound startup actions here
        /// </summary>
        public override Task Startup()
        {
            return base.Startup();
        }


        /// <summary>
        /// If the application is restarted (eg primary activity on Android 
        /// can be restarted) this method will be called before Startup
        /// is called again
        /// </summary>
        public override void Reset()
        {
            base.Reset();
        }
    }
}
