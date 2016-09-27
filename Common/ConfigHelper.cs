using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public static class ConfigHelper
    {
      
       public static string SERVICE_FILE =System.Configuration.ConfigurationManager.AppSettings["serviceFile"];
       public static string LIB_RULE = "*.Library.dll";
    }
}
