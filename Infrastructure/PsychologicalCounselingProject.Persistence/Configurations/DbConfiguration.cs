using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PsychologicalCounselingProject.Persistence.Configurations
{
    public static class DbConfiguration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/PsychologicalCounselingProject.WebApi"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("PostgreSQL");
            }
        }
    }
}
