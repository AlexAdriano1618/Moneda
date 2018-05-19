using System;
using System.Collections.Generic;
using System.Text;
using Moneda.ViewModels;
namespace Moneda.Infrastructure
{
    
    public class InstanceLocator
    {
        #region porpiedades
        public MainViewModel Main
        {
            get;
            set;

        }
        #endregion
        #region Constructor
        public InstanceLocator()
        {
            this.Main = new MainViewModel();

        }
        #endregion
    }
}
