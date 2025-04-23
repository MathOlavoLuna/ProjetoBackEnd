using API_VidaPlus.Data;
using API_VidaPlus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_VidaPlus.Services.Geral
{
    public class CRUDService<T> where T : class 
    {
        private readonly DataContext _context;
        public CRUDService(DataContext context)
        { //injeção de dependência;
            _context = context;
        }

        [HttpGet]
        public async Task<List<T>> ReadAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        [HttpGet]
        public async Task<T> ReadId(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        [HttpPost]
        public async Task<T> Create(T Entity)
        {
            await _context.AddAsync<T>(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }

        [HttpPut]
        public async Task<T> Update(T Entity)
        {
            _context.Update<T>(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }

        [HttpDelete]
        public async Task<T> Delete(T Entity)
        {
            _context.Set<T>().Remove(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }
    }
}
