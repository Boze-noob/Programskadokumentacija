using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    /// <summary>
    /// Prikaz proizvođača vozila
    /// </summary>
    public class ProizvodjaciViewModel
    {
        public IEnumerable<Proizvodjaci> Proizvodjaci { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}