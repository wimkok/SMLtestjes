using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace SMLtestjes
{
    internal class Smp
    {
        // http://b-643cf853e92ef213d236d122502950fa.iso6523-actorid-upis.acc.edelivery.tech.ec.europa.eu/iso6523-actorid-upis::9925:0316380841

        private string participantID;
        private Sml sml;
        private bool unread = true;
        public bool Published { get; internal set; }

        public Smp(string v)
        {
            this.participantID = v;
            sml = new Sml(participantID);
            Published = sml.HostExists();
            if (unread && Published )
            {
                Read();
            }
        }
        public override string ToString()
        {
            return "" + sml + sml.Recepient.Scheme+"::"+ sml.Recepient.ToString();
        }

        private void Read()
        {
            WebRequest request = WebRequest.Create(this.ToString());
            WebResponse response = request.GetResponse();
            Stream datastream = response.GetResponseStream();
            StreamReader reader = new StreamReader(datastream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);

            var xdoc = XDocument.Load(ToStream(responseFromServer));
            var serviceGroup = new ServiceGroup(xdoc);
            Console.WriteLine($"\nxdoc ParticipantIdentifier =  {serviceGroup.ParticipantIdentifier.Identifier}");


            //Console.ReadKey();
            XmlSerializer serializer = new XmlSerializer(typeof(ServiceGroupType));
            ServiceGroupType deserialized = (ServiceGroupType)serializer.Deserialize(ToStream(responseFromServer));

            Console.WriteLine("\nParticipantIdentifier.Value = " + deserialized.ParticipantIdentifier);
            Console.WriteLine("\nFirst().href = " + deserialized.ServiceMetadataReferenceCollection.First().href);

            unread = false;

        }
        public static Stream ToStream(string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

    }
}