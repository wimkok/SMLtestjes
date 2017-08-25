using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SMLtestjes
{
    internal class ServiceGroup
    {
        protected XDocument Xdoc;
        public ParticipantIdentifier ParticipantIdentifier;

        protected XPathNavigator Navigator;
        protected XmlNamespaceManager Manager;

        public ServiceGroup(XDocument xdoc)
        {
            this.Xdoc = xdoc;
            Navigator = Xdoc.CreateNavigator();

            if (Navigator.NameTable == null)
                throw new Exception("Ubl doesn't have a name table.");

            Manager = new XmlNamespaceManager(Navigator.NameTable);
            Manager.AddNamespace("base", "http://busdox.org/serviceMetadata/publishing/1.0/");
            Manager.AddNamespace("ids", "http://busdox.org/transport/identifiers/1.0/");
            Manager.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");

            ParticipantIdentifier = new ParticipantIdentifier(Evaluate<string>("string(//ids:ParticipantIdentifier/text())"));

            var values = from id in Xdoc.XPathSelectElements("//base:ServiceMetadataReferenceCollection/base:ServiceMetadataReference", Manager)
                         select new Uri(id.Attribute("href").Value);
            foreach (var value in values)
            {
                Console.WriteLine("Value = " + value);
            }
        }

        public T Evaluate<T>(string xpath)
        {
            if (string.IsNullOrWhiteSpace(xpath))
                return default(T);

            return (T)Xdoc.XPathEvaluate(xpath, Manager);
        }

    }
}