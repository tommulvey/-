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

        public async Task<Page> GetPageTitleById(int id)
        {
            return await Context.Pages.SingleOrDefaultAsync(e => e.id == id);
        }

        public async Task<Page> GetPageIdByTitle(string title)
        {
            return await Context.Pages.SingleOrDefaultAsync(e => e.title == title);
        }

        public async Task<Page> GetPageTextById(int id)
        {
            return await Context.Pages.SingleOrDefaultAsync(e => e.id == id);
        }

        public async Task<Page> GetPageTextByTitle(string title)
        {
            return await Context.Pages.SingleOrDefaultAsync(e => e.title == title);
        }
    }
}
