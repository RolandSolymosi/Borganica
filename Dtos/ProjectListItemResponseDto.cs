using Borganica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borganica.Dtos
{
    public class ProjectListItemResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public State State { get; set; }
        public string Creator { get; set; }
        public GeoLocationDto Location { get; set; }
        public Decimal Profit { get; set; }
    }

    public static partial class ModelExtensions
    {
        public static ProjectListItemResponseDto ToDto(this Project entity)
        {
            return new ProjectListItemResponseDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Created = entity.Created,
                State = entity.State,
                Creator = entity.Creator,
                Location = new GeoLocationDto {
                    Latitude = entity.Location.Latitude,
                    Longitude = entity.Location.Longitude,
                    CityName = entity.Location.CityName
                },
                Profit = entity.Profit
            };
        }
    }
}
