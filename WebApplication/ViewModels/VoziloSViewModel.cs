using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    /// <summary>
    /// Postavljanje osnovnih podataka o vozilu , njegova dostupnost, slike
    /// </summary>
    public class VozilosViewModel
    {
        public int IdVozila { get; set; }
        public string NazivProizvodjaca { get; set; }
        public ModelViewModel Model { get; set; }
        public int Cijena { get; set; }
        public bool Dostupno { get; set; }
        
        public int? IdSlike { get; set; }

    }
}