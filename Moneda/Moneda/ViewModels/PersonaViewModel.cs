
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
    public class PersonaViewModel : BaseViewModel
    {

        #region Attributes
        //private ObservableCollection<Border> borders;
        //private ObservableCollection<Currency> currencies;
        //private ObservableCollection<Language> languages;
        #endregion

        #region Propperties
        public Persona Persona
        {
            get;
            set;
        }

        //public ObservableCollection<Border> Borders
        //{
        //    get { return this.borders; }
        //    set { this.SetValue(ref this.borders, value); }
        //}

        //public ObservableCollection<Currency> Currencies
        //{
        //    get { return this.currencies; }
        //    set { this.SetValue(ref this.currencies, value); }
        //}

        //public ObservableCollection<Language> Languages
        //{
        //    get { return this.languages; }
        //    set { this.SetValue(ref this.languages, value); }
        //}
        #endregion

        #region Constructors
        public PersonaViewModel(Persona persona)
        {
            this.Persona = persona;
            //this.LoadBorders();
            //this.Currencies = new ObservableCollection<Currency>(this.Pais.Currencies);
            //this.Languages = new ObservableCollection<Language>(this.Pais.Languages);
        }
        #endregion

        #region Methods
        private void LoadBorders()
        {
            //this.Borders = new ObservableCollection<Border>();
            //foreach (var border in this.Pais.Borders)
            //{
            //    var land = MainViewModel.GetInstance().LandsList.
            //                            Where(l => l.Alpha3Code == border).
            //                            FirstOrDefault();
            //    if (land != null)
            //    {
            //        this.Borders.Add(new Border
            //        {
            //            Code = land.Alpha3Code,
            //            Name = land.Name,
            //        });
            //    }
            //}
        }
        #endregion
    }
}
