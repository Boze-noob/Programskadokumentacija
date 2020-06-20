using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    /// <summary>
    /// Postavljanje vrste goriva
    /// </summary>
    public class VrsteGorivaViewModel
    {
        public IEnumerable<VrsteGoriva> VrsteGoriva { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}