using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WikiSpeedia.Abstractions;
using WikiSpeedia.Objects;
namespace WikiSpeedia.Repos
{
    public class PageRepository : IPageRepository
    {
        public MSSQLDbContext Context { get; }

        public PageRepository(MSSQLDbContext context)
        {
            Context = context;
        }

        public  IQueryable<Page> GetAllPages()
        {
            return Context.Pages.AsQueryable();
        }
        public async Task<string> GetPageTitleById(int id)
        {
            //return await Context.Pages.SingleOrDefaultAsync(e => e.id == id);

            return await GetAllPages().Where(item => item.id == id).Select(item => item.title).FirstOrDefaultAsync();
            //return await Context.Pages.SingleOrDefaultAsync(e => e.id == id);
        }

        public async Task<Page> GetPageIdByTitle(string title)
        {
            return await Context.Pages.SingleOrDefaultAsync(e => e.title == title);
        }

        public async Task<string> GetPageTextById(int id)
        {
            return await GetAllPages().Where(item => item.id == id).Select(item => item.text).FirstOrDefaultAsync();
        }

        public async Task<Page> GetPageTextByTitle(string title)
        {
            return await Context.Pages.SingleOrDefaultAsync(e => e.title == title);
        }
    }
}
