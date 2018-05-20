
namespace Moneda.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    // using Helpers;
    using Models;
    using Services;
    using Xamarin.Forms;
    public class PaisesViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<Pais> paises;
        private bool isRefreshing;
        private string filter;
        private List<Pais> ListaPaises;
        #endregion

        #region Properties
        public ObservableCollection<Pais> Paises
        {
            get { return this.paises; }
            set { SetValue(ref this.paises, value); }
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
        public PaisesViewModel()
        {
            this.apiService = new ApiService();
            this.LoadPaises();
        }
        #endregion

        #region Methods
        private async void LoadPaises()
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
            var response = await this.apiService.GetList<Pais>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all");
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
            this.ListaPaises = (List<Pais>)response.Result;
            this.Paises = new ObservableCollection<Pais>(this.ListaPaises);
            this.IsRefreshing = false;


            //var connection = await this.apiService.CheckConnection();

            //if (!connection.IsSuccess)
            //{
            //    this.IsRefreshing = false;
            //    await Application.Current.MainPage.DisplayAlert(
            //        Languages.Error,
            //        connection.Message,
            //        Languages.Accept);
            //    await Application.Current.MainPage.Navigation.PopAsync();
            //    return;
            //}

            //var response = await this.apiService.GetList<Pais>(
            //    "http://restcountries.eu",
            //    "/rest",
            //    "/v2/all");

            //if (!response.IsSuccess)
            //{
            //    this.IsRefreshing = false;
            //    await Application.Current.MainPage.DisplayAlert(
            //        Languages.Error,
            //        response.Message,
            //        Languages.Accept);
            //    await Application.Current.MainPage.Navigation.PopAsync();
            //    return;
            //}

            //MainViewModel.GetInstance().LandsList = (List<Land>)response.Result;
            //this.Lands = new ObservableCollection<LandItemViewModel>(
            //    this.ToLandItemViewModel());
            //this.IsRefreshing = false;
        }
        #endregion

        #region Methods
        //private IEnumerable<Pais> ToLandItemViewModel()
        //{
        //    //return MainViewModel.GetInstance().ListaPaises.Select(l => new Pais
            //{
            //    Alpha2Code = l.Alpha2Code,
            //    Alpha3Code = l.Alpha3Code,
            //    AltSpellings = l.AltSpellings,
            //    Area = l.Area,
            //    Borders = l.Borders,
            //    CallingCodes = l.CallingCodes,
            //    Capital = l.Capital,
            //    Cioc = l.Cioc,
            //    Currencies = l.Currencies,
            //    Demonym = l.Demonym,
            //    Flag = l.Flag,
            //    Gini = l.Gini,
            //    Languages = l.Languages,
            //    Latlng = l.Latlng,
            //    Name = l.Name,
            //    NativeName = l.NativeName,
            //    NumericCode = l.NumericCode,
            //    Population = l.Population,
            //    Region = l.Region,
            //    RegionalBlocs = l.RegionalBlocs,
            //    Subregion = l.Subregion,
            //    Timezones = l.Timezones,
            //    TopLevelDomain = l.TopLevelDomain,
            //    Translations = l.Translations,
            //});
        //}

        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadPaises);
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
                this.Paises = new ObservableCollection<Pais>(
                    this.ListaPaises);
            }
            else
            {
                this.Paises = new ObservableCollection<Pais>(
                    this.ListaPaises.Where(
                        l => l.Name.ToLower().Contains(this.Filter.ToLower()) ||
                             l.Capital.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion
    }
}
