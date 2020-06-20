using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    /// <summary>
    /// Prikaz odjela
    /// </summary>
    public class OdjeliViewModel
    {
        public IEnumerable<Odjeli> Odjeli { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}