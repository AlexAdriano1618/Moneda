using System;
using System.Collections.Generic;
using System.Text;

namespace Moneda.ViewModels
{
    public class MainViewModel
    {
        #region ViewModel
        public LoginViewModel Login
        {
            get;
            set;
        }
        public PaisesViewModel Paises
        {
            get;
            set;
        }
        public PaisViewModel Pais
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            Instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion

        #region Singleton

        private static MainViewModel Instance;
        public static MainViewModel GetInstance()
        {
            if (Instance == null)
            {
                return new MainViewModel();
            }
            return Instance;
        }
        #endregion
    }
}
