using BookStore.API.Data;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class StaticPagesRepository : IStaticPagesRepository
    {
        private readonly BookStoreDbContext _context;

        public StaticPagesRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<StaticPages>> GetAllAsync()
        {
            return await _context.StaticPages.ToListAsync();
        }

        public async Task<StaticPages> GetByIdAsync(int id)
        {
            return await _context.StaticPages.FirstOrDefaultAsync(b => b.Id == id);
        }



        public async Task<StaticPages> GetByPageSlugAsync(string slug)
        {
            return await _context.StaticPages.FirstOrDefaultAsync(sp => sp.Slug == slug);
        }

        public async Task<StaticPages> CreateAsync(StaticPages staticPageToCreate)
        {
            await _context.StaticPages.AddAsync(staticPageToCreate);
            await _context.SaveChangesAsync();
            return staticPageToCreate;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var staticPage = await _context.StaticPages.FindAsync(id);
            if (staticPage == null) return false;

            _context.StaticPages.Remove(staticPage);
            return await _context.SaveChangesAsync() > 0;
        }



        public async Task<StaticPages> UpdateAsync(int id, StaticPages staticPageToUpdate)
        {
            var staticPage = await _context.StaticPages.FirstOrDefaultAsync(a => a.Id == id);
            if (staticPage == null) return null;

            staticPage.PageName = staticPageToUpdate.PageName;
            staticPage.Details = staticPageToUpdate.Details;
            await _context.SaveChangesAsync();

            return staticPage;
        }

       
    }
}
