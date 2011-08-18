using System;
using System.Configuration;

namespace Core.Services
{
    public class WebConfigurationService : ConfigurationService
    {
        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["default"].ConnectionString; }
        }
    }
}