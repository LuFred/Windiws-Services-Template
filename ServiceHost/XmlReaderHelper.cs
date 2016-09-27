using ServiceHost.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ServiceHost
{
    public static class XmlReaderHelper
    {
        public static ServiceModel ReadXml(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            XmlReader reader = XmlReader.Create(path, settings);
            xmlDoc.Load(reader);
            XmlNode xns = xmlDoc.SelectSingleNode("ServiceList");
            ServiceModel model = new ServiceModel();

           XmlNode ServiceDefinitionNode=xns.SelectSingleNode("ServiceDefinition");
            model.ServiceDefinition.ServiceName = ServiceDefinitionNode.Attributes["Name"].Value;
            model.ServiceDefinition.ServiceDescription = ServiceDefinitionNode.SelectSingleNode("Description").InnerText;

            XmlNode ServiceNode = ServiceDefinitionNode.SelectSingleNode("Service");

            model.ServiceDefinition.Service.LongCheckForWorkInterVal = ServiceNode.SelectSingleNode("LongCheckForWorkInterVal").InnerText;
            model.ServiceDefinition.Service.MaxThreads =Convert.ToInt32(ServiceNode.SelectSingleNode("MaxThreads").InnerText);

            reader.Close();
            return model;

        }
    }
}
