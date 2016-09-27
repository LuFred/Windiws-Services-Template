using Common;
using ServiceHost.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHost
{
    public class Host
    {
        public void ServiceInit(System.ServiceProcess.ServiceInstaller serviceInstaller)
        {
             ServiceModel model = XmlReaderHelper.ReadXml(@".\Config\Service.xml");
            serviceInstaller.ServiceName = model.ServiceDefinition.ServiceName;
            serviceInstaller.Description = model.ServiceDefinition.ServiceDescription;
        }
    }
}
