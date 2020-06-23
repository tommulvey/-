using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WikiSpeedia.Abstractions;
using WikiSpeedia.Objects;
using Newtonsoft.Json;
using WikiSpeedia.DI;
using WikiSpeedia.Repos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization;
using Microsoft.EntityFrameworkCore;
using System.Net;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WikiSpeedia.Controllers
{

    [Route("v1/PageTextById")]
    public class PageTextByIdController : Controller
    {
        //repo
        public IPageRepository PageRepository { get; }

        public PageTextByIdController()
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
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = PageRepository.GetPageTextById(id);
            if(result.Result == null){
                return BadRequest("Invalid id #");
            }
            return Ok(result.Result);
            //return Ok();
        }

        // most of our app is just reading. atleast for pages. only gets for now :) 
        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
