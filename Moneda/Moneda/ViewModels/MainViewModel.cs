using System;
using System.Collections.Generic;
using System.Text;

namespace Moneda.ViewModels
{
    using Models;
    public class MainViewModel
    {
        #region Propiedades
        public List<Pais> ListaPaises
        {
            get;
            set;
        }
        public List<Persona> ListaPersona
        {
            get;
            set;
        }
        #endregion
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
        public PersonasViewModel Personas
        {
            get;
            set;
        }
        public PersonaViewModel Persona
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
