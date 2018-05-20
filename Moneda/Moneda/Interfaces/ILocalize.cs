﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Moneda.Interfaces
{
    using System.Globalization;

    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale(CultureInfo ci);
    }
}
