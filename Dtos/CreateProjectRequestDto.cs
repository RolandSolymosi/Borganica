using Borganica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Borganica.Dtos
{
    public class CreateProjectRequestDto
    {
        public string Name { get; set; }
        public GeoLocationDto Location { get; set; }
        public Decimal Profit { get; set; }

        public Project ToEntity(string userName)
        {
            return new Project
            {
                Name = Name,
                Created = DateTimeOffset.Now,
                Creator = userName,
                Location = new GeoLocation {
                    Latitude = Location.Latitude,
                    Longitude = Location.Longitude,
                    CityName = Location.CityName
                },
                Profit = Profit
            };
        }
    }
}
