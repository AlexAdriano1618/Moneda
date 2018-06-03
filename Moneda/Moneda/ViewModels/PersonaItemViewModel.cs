
namespace Moneda.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;
    public class PersonaItemViewModel : Persona
    {
        #region Commands
        public ICommand SelectLandCommand
        {
            get
            {
                return new RelayCommand(SelectLand);
            }
        }

        private async void SelectLand()
        {
            MainViewModel.GetInstance().Persona = new PersonaViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new PaisPage());
        }
        #endregion
    }
}
