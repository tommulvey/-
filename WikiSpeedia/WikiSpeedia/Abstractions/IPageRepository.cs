using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WikiSpeedia.Objects;
namespace WikiSpeedia.Abstractions
{
    public interface IPageRepository
    {
        Task<string> GetPageTitleById(int id); // get a wiki page tile based off of ID
        Task<Page> GetPageIdByTitle(string name); // get a wiki page id by article name (clicked from ahref :P )
        Task<string> GetPageTextById(int id); // get a wiki page text based off of ID
        Task<Page> GetPageTextByTitle(string name); // get a wiki page text by article name (clicked from ahref :P )
        IQueryable<Page> GetAllPages();
    }
}
