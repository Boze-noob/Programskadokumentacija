using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    /// <summary>
    /// Postavljanje zahtjeva
    /// </summary>
    public class ZahtjeviViewModel
    {
        public IEnumerable<ZahtjevViewModel> Zahtjevi { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}