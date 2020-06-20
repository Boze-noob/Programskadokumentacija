using System;

namespace WebApplication.ViewModels
{
    /// <summary>
    /// Određivanje ukupnog broja predmeta na stranici
    /// </summary>
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public bool  Ascending { get; set; }
        public int Sort { get; set; }
        public int TotalPages
        {
            get { return (int) Math.Ceiling( (decimal) TotalItems / ItemsPerPage); }
        }
    }
}