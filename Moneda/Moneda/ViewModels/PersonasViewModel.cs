
namespace Moneda.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    // using Helpers;
    using Models;
    using Services;
    using Xamarin.Forms;
    public class PersonasViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<PersonaItemViewModel> personas;
        private bool isRefreshing;
        private string filter;
        // private List<Pais> ListaPaises;
        #endregion

        #region Properties
        public ObservableCollection<PersonaItemViewModel> Personas
        {
            get { return this.personas; }
            set { SetValue(ref this.personas, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {

            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        #endregion

        #region Constructors
        public PersonasViewModel()
        {
            this.apiService = new ApiService();
            this.LoadPersonas();
        }
        #endregion

        #region Methods
        private async void LoadPersonas()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var response = await this.apiService.GetList<Persona>(
                "http://coreservicioapp.azurewebsites.net",
                "/api",
                "/Personas");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            MainViewModel.GetInstance().ListaPersona = (List<Persona>)response.Result;
            this.Personas = new ObservableCollection<PersonaItemViewModel>(
                this.ToPersonaItemViewModel());
            this.IsRefreshing = false;

        }


        #endregion

        #region Methods
        private IEnumerable<PersonaItemViewModel> ToPersonaItemViewModel()
        {
            return MainViewModel.GetInstance().ListaPersona.Select(l => new PersonaItemViewModel
            {
                Id= l.Id,
                Cedula =l.Cedula,
                Nombres = l.Nombres,
                Apelllidos = l.Apelllidos,
                Email = l.Email
            });
        }

        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadPersonas);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Personas = new ObservableCollection<PersonaItemViewModel>(
                    this.ToPersonaItemViewModel());
            }
            else
            {
                this.Personas = new ObservableCollection<PersonaItemViewModel>(
                    this.ToPersonaItemViewModel().Where(
                        l => l.Cedula.ToLower().Contains(this.Filter.ToLower()) ||
                             l.Apelllidos.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion
    }
}
