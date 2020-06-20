using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    /// <summary>
    /// Prikaz zaposlenih vozaca,njihovo postavljanje
    /// </summary>
    public class ZaposleniciViewModel
    {
        public IEnumerable<ZaposlenikViewModel> Zaposlenici { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}