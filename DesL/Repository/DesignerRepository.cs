using DesL.Data;
using DesL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesL.Repository
{
    public class DesignerRepository : IDesignerRepository
    {
        private readonly AppDbContext _context;

        public DesignerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Designer entity)
        {
            await _context.Designers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Designer entity)
        {
            _context.Designers.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Designer>> GetAll()
        {
            return await _context.Designers.ToListAsync();
        }

        public async Task<Designer> GetById(int id)
        {
            return await _context.Designers.FindAsync(id);
        }

        public async Task Update(Designer entity)
        {
            _context.Designers.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
