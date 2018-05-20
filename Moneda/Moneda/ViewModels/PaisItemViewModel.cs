
namespace Moneda.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;
    public class PaisItemViewModel : Pais
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
            MainViewModel.GetInstance().Pais = new PaisViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new PaisPage());
        }
        #endregion
    }
}
