using Borganica.Models;
using Borganica.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Borganica.Services
{
    public class ProjectsService : IProjectsService
    {
        public ProjectsService(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;

        public async Task<IReadOnlyCollection<Project>> GetAll()
        {
            return await _context.Projects
                .Include(p => p.Location)
                .ToListAsync();
        }

        public async Task<Project> GetById(int id)
        {
            return await _context.Projects
                .Include(p => p.Location)
                .SingleAsync(p => p.Id == id);
        }

        public async Task Create(Project entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Projects.Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task Update(Project entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Projects.Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
