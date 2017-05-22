using Borganica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Borganica.Dtos
{
    public class ModifyProjectStateResponseDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public State State { get; set; }
    }

    public static partial class ModelExtensions
    {
        public static ModifyProjectStateResponseDto ToClientDto(this Project entity)
        {
            return new ModifyProjectStateResponseDto
            {
                Id = entity.Id,
                Name = entity.Name,
                State = entity.State
            };
        }
    }
}
