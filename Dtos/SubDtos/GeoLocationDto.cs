using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borganica.Dtos
{
    public class GeoLocationDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CityName { get; set; }
    }
}
