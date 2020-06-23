using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WikiSpeedia.Abstractions
{
    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
    }
}
