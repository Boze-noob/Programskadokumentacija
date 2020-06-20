using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    /// <summary>
    /// Postavljanje Vozilo viewa u info izbornik
    /// </summary>
    public class VozilaViewModel
    {
        public IEnumerable<VoziloViewModel> Vozila { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}