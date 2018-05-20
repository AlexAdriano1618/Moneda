﻿using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Moneda.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region MyRegion
        private string contrasena { get; set; }
        private string isEnable { get; set; }
        private string isRunnig { get; set; }
        #endregion

        #region Propiedades
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public bool IsRunnig { get; set; }
        public bool Recordado { get; set; }
        public bool IsEnable { get; set; }
        #endregion

        #region constructor

        public LoginViewModel()
        {
            this.Recordado = true;

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
            }
            if (string.IsNullOrEmpty(this.Contrasena))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an Password.",
                    "Accept");
            }
            if (this.Email != "alexliga1998@outlook.com" || this.Contrasena != "1234")
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or Password incorrect.",
                    "Accept");
                this.Contrasena = string.Empty;
            }
            await Application.Current.MainPage.DisplayAlert(
                    "OK",
                    "Email or Password incorrect.",
                    "Accept");
        }
        #endregion

    }

}
