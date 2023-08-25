using BookStore.API.Data;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookStoreDbContext _context;

        public CategoryRepository(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.Include(c=>c.Books).FirstOrDefaultAsync(b => b.Id ==id);
        }


        public async Task<Category> CreateAsync(Category categoryToCreate)
        {
            await _context.Categories.AddAsync(categoryToCreate);
            await _context.SaveChangesAsync();
            return categoryToCreate;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync() > 0;
        }



        public async Task<Category> UpdateAsync(int id, Category categoryToUpdate)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(a => a.Id == id);
            if (category == null) return null;

            category.Name = categoryToUpdate.Name;
            await _context.SaveChangesAsync();

            return category;
        }
    }
}
