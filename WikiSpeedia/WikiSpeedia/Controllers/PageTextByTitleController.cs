using Microsoft.AspNetCore.Mvc;
using WikiSpeedia.Abstractions;
using WikiSpeedia.DI;
using WikiSpeedia.Repos;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WikiSpeedia.Controllers
{

    [Route("v1/PageTextByTitle")]
    public class PageTextByTitleController : Controller
    {
        //repo
        public IPageRepository PageRepository { get; }

        public PageTextByTitleController()
        {
            //DI
            var resolver = new DependencyResolver(ConfigureServices);
            // Get products repo
            PageRepository = resolver.ServiceProvider.GetService<IPageRepository>();

        }

        // Register services with DI system
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPageRepository, PageRepository>();
        }

        // GET api/<controller>/5
        [HttpGet("{title}")]
        public IActionResult Get(string title)
        {
            var result = PageRepository.GetPageTextByTitle(title);
            if(result.Result == null){
                return BadRequest("Invalid title stepbro");
            }
            return Ok(result.Result);
            //return Ok();
        }
    }
}
