using BookStore.API.Data;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class TranslatorRepository : ITranslatorRepository
    {
        private readonly BookStoreDbContext _context;

        public TranslatorRepository(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<Translator>> GetAllTranslatorsAsync()
        {
            return await _context.Translators.ToListAsync();
        }

        public async Task<Translator> GetTranslatorByIdAsync(int id)
        {
            return await _context.Translators.Include(c => c.Books).FirstOrDefaultAsync(b => b.Id == id);
        }


        public async Task<Translator> CreateAsync(Translator translatorToCreate)
        {
            await _context.Translators.AddAsync(translatorToCreate);
            await _context.SaveChangesAsync();
            return translatorToCreate;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var translator = await _context.Translators.FindAsync(id);
            if (translator == null) return false;

            _context.Translators.Remove(translator);
            return await _context.SaveChangesAsync() > 0;
        }



        public async Task<Translator> UpdateAsync(int id, Translator translatorToUpdate)
        {
            var translator = await _context.Translators.FirstOrDefaultAsync(a => a.Id == id);
            if (translator == null) return null;

            translator.Name = translatorToUpdate.Name;
            await _context.SaveChangesAsync();

            return translator;
        }

    }
}
