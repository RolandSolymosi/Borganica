using Borganica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borganica.Services
{
    public interface IProjectsService
    {
        Task<IReadOnlyCollection<Project>> GetAll();
        Task<Project> GetById(int id);
        Task Create(Project project);
        Task Update(Project project);
    }
}
