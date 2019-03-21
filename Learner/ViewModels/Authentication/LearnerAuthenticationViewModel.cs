using System.Collections.ObjectModel;
using Caliburn.Micro;
using Resources.Helper;

namespace Learner.ViewModels.Authentication
{
    public class LearnerAuthenticationViewModel : Screen
    {
        private ObservableCollection<string> _languages;
        private string _selectedLanguage;

        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                _selectedLanguage = value;
                NotifyOfPropertyChange(nameof(SelectedLanguage));
                LanguageHelper.SelectCulture(SelectedLanguage);
            }
        }
        public ObservableCollection<string> Languages
        {
            get => _languages;
            set
            {
                _languages = value;
                NotifyOfPropertyChange(nameof(Languages));
            }
        }

        protected override void OnActivate()
        {
            Languages=new ObservableCollection<string>();
            LanguageHelper.AddLanguages(Languages, "pack://application:,,,/Resources;component/Languages");
            base.OnActivate();
        }

        public void Exit(bool exit)
        {
            this.TryClose(exit);
        }
    }
}
