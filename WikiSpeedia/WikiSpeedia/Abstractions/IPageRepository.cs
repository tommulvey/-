using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WikiSpeedia.Objects;
namespace WikiSpeedia.Abstractions
{
    public interface IPageRepository
    {
        Task<Page> GetPageById(int id); // get a wiki page based off of ID
        Task<Page> GetPageByName(string name); // get a wiki page by article name (clicked from ahref :P )
    }
}
