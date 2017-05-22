using Borganica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Borganica.Dtos
{
    public class ModifyProjectStateRequestDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public State State { get; set; }
    }

    public static partial class DtoExtensions
    {
        public static bool ApplyChanges(this Project project, ModifyProjectStateRequestDto dto)
        {
            if (project.State == State.Lead)
            {
                if (dto.State == State.Rejected || dto.State == State.Contracted)
                {
                    project.State = dto.State;
                    return true;
                }
            }

            if (project.State == State.Contracted)
            {
                if (dto.State == State.Cancelled || dto.State == State.UnderConstruction)
                {
                    project.State = dto.State;
                    return true;
                }
            }

            if (project.State == State.UnderConstruction)
            {
                if (dto.State == State.Cancelled || dto.State == State.Finished)
                {
                    project.State = dto.State;
                    return true;
                }
            }

            return false;
        }
    }
}
