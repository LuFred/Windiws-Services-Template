using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHost.Model
{
    public class ServiceModel
    {
        public ServiceModel()
        {
            ServiceDefinition = new ServiceDefinition();
        }

        public ServiceDefinition ServiceDefinition { get; set; }



    }
    public class Service
    {
        public string LongCheckForWorkInterVal { get; set; }
        public int MaxThreads { get; set; }
    }
    public class ServiceDefinition
    {
        public ServiceDefinition()
        {
            Service = new Service();
        }
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
        public Service Service { get; set; }

    }
}
