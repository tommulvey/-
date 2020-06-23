using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WikiSpeedia.Abstractions;
namespace WikiSpeedia.Objects
{
    public class Page
    {
        public int id { get; set; }
        public string title { get; set; }
        public string text { get; set; }
    }
}
