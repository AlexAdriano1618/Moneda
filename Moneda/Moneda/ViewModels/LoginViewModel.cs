

namespace Moneda.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    public class LoginViewModel : BaseViewModel
    {

        #region Atributos
        private string email;
        private string contrasena;
        private bool isEnable;
        private bool isRunnig;
        #endregion

        #region Propiedades
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }

        }
        public string Contrasena
        {
            get { return this.contrasena; }
            set { SetValue(ref this.contrasena, value); }
        }
        public bool IsRunnig
        {
            get { return this.isRunnig; }
            set { SetValue(ref this.isRunnig, value); }
        }
        public bool Recordado { get; set; }
        public bool IsEnable
        {
            get { return this.isEnable; }
            set { SetValue(ref this.isEnable, value); }
        }
        #endregion

        #region constructor

        public LoginViewModel()
        {
            this.Recordado = true;
            this.IsEnable = true;
            this.Email = "alexliga1998@outlook.com";
            this.Contrasena = "1234";
           // http://restcountries.eu/rest/v2/all

        }
        #endregion

        #region Command
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }



        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email.",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Contrasena))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an Password.",
                    "Accept");
                return;
            }

            this.IsRunnig = true;
            this.IsEnable = false;

            if (this.Email != "alexliga1998@outlook.com" || this.Contrasena != "1234")
            {
                this.IsRunnig = false;
                this.IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or Password incorrect.",
                    "Accept");
                this.Contrasena = string.Empty;
                return;
            }
            this.IsRunnig = false;
            this.IsEnable = true;

            this.Email = string.Empty;
            this.Contrasena = string.Empty;
            // estableciedo la clase la clase MainviewModel
            MainViewModel.GetInstance().Paises = new PaisesViewModel();
            await Application.Current.MainPage.Navigation.PushModalAsync( new PaisesPage());


        }
        #endregion

    }

}
