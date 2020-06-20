using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    /// <summary>
    /// Popunjavanje osnovnih podataka o svakom vozaču
    /// </summary>
    public class ZaposlenikViewModel
    {
        public int IdZaposlenika { get; set; }
        public string NazivOdjela { get; set; }
        public string ImeOsobe { get; set; }
        public int? RadniStaz { get; set; }
    }
}