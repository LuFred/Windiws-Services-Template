using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHost.Model
{
   public class ServiceModel
   {
       public ServiceModel() { }
       private string _serviceName;

       public string ServiceName
       {
           get { return _serviceName; }
           set { _serviceName = value; }
       }
       private string _serviceDescription;

       public string ServiceDescription
       {
           get { return _serviceDescription; }
           set { _serviceDescription = value; }
       }
    }
}
