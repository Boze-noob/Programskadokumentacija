using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    /// <summary>
    /// Postavljanje Usluge viewa
    /// </summary>
    public class UslugeViewModel
    {
        public IEnumerable<UslugaViewModel> Usluge { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}