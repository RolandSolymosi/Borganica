using System;
using System.Collections.Generic;
using System.Text;

namespace Borganica.Models
{
    public class GeoLocation
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CityName { get; set; }
    }
}
