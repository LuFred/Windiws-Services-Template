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
        public static ServiceModel ReadXml(string path) {
            XmlDocument xmlDoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            XmlReader reader = XmlReader.Create(path, settings);
            xmlDoc.Load(reader);
            XmlNode xns = xmlDoc.SelectSingleNode("ServiceList");
            ServiceModel model = new ServiceModel();
            foreach (XmlNode node in xns)
            {
                XmlElement xe = (XmlElement)node;
                model.ServiceName = xe.GetAttribute("Name");
                XmlNodeList serverNodes = xe.ChildNodes;
                model.ServiceDescription = serverNodes.Item(0).InnerText;
            }
            reader.Close();
            return model;
        
        }
    }
}
