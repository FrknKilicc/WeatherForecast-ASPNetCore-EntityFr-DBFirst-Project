using System;
using System.Collections.Generic;

namespace WeatherForecastASPNetCoreDBFirst.Models
{
    public partial class Sehirler
    {
        public Sehirler()
        {
            HavaDurumus = new HashSet<HavaDurumu>();
        }

        public int SehirId { get; set; }
        public string? SehirAdi { get; set; }
        public string? Ulke { get; set; }
        public decimal? Enlem { get; set; }
        public decimal? Boylam { get; set; }

        public virtual ICollection<HavaDurumu> HavaDurumus { get; set; }
    }
}
