using System.Windows;
using Caliburn.Micro;
using Learner.ViewModels.Authentication;

namespace Learner
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<LearnerAuthenticationViewModel>();
        }
    }
}
