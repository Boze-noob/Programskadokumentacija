using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    /// <summary>
    /// Postavljanje naziva usluga i kategorija
    /// </summary>
    public class UslugaViewModel
    {
        public int IdUsluge { get; set; }
        public string NazivKategorije { get; set; }
        public string NazivUsluge { get; set; }
    }
}