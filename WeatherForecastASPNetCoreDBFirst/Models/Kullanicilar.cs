using System;
using System.Collections.Generic;

namespace WeatherForecastASPNetCoreDBFirst.Models
{
    public partial class Kullanicilar
    {
        public int KullaniciId { get; set; }
        public string? KullaniciAdi { get; set; }
        public string? SifreHash { get; set; }
    }
}
