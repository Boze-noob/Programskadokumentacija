using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    /// <summary>
    /// Određivanje vrste mjenjača 
    /// </summary>
    public class MjenjaciViewModel
    {
        public IEnumerable<Mjenjaci> Mjenjaci { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}