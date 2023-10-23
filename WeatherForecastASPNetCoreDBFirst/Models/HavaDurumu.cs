using System;
using System.Collections.Generic;

namespace WeatherForecastASPNetCoreDBFirst.Models
{
    public partial class HavaDurumu
    {
        public int DurumId { get; set; }
        public int? SehirId { get; set; }
        public DateTime? Tarih { get; set; }
        public TimeSpan? Saat { get; set; }
        public double? DereceCelcius { get; set; }
        public int? NemOrani { get; set; }
        public int? RuzgarHizi { get; set; }
        public string? Aciklama { get; set; }

        public virtual Sehirler? Sehir { get; set; }
    }
}
