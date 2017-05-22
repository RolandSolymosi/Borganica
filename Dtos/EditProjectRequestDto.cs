using Borganica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Borganica.Dtos
{
    public class EditProjectRequestDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public GeoLocationDto Location { get; set; }
        [Required]
        public decimal Profit { get; set; }
    }

    public static partial class DtoExtensions
    {
        public static void ApplyChanges(this Project project, EditProjectRequestDto dto)
        {
            project.Name = dto.Name;
            project.Location.Longitude = dto.Location.Longitude;
            project.Location.Latitude = dto.Location.Latitude;
            project.Location.CityName = dto.Location.CityName;
            project.Profit = dto.Profit;
        }
    }
}
