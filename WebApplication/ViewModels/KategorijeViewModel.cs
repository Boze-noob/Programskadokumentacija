using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    /// <summary>
    /// Izbornik kategorije vozila
    /// </summary>
    public class KategorijeViewModel
    {
        public IEnumerable<Kategorije> Kategorije { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}