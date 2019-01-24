using System;
using System.Threading.Tasks;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using ClaimIt.Core.ViewModels;
using MvvmCross;
using ClaimIt.Core.Services;
using ClaimIt.UI.Services;

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

            RegisterAppStart<VerifyParticipantViewModel>();


            Mvx.IoCProvider.RegisterType<IDialogService, DialogService>();
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
