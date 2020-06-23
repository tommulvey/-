using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using WikiSpeedia.Abstractions;

namespace WikiSpeedia.Objects
{
    public class EnviornmentService : IEnviornmentService
    {
        public EnviornmentService()
        {

            EnviornmentName = Environment.GetEnvironmentVariable(Constants.EnvironmentVariables.AspnetCoreEnvironment)
                ?? Constants.Environments.Production;
        }

        public string EnviornmentName { get; set; }
    }
}
