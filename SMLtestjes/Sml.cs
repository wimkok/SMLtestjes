using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace SMLtestjes
{
    internal class Sml
    {
        public const string SMK = "acc.edelivery.tech.ec.europa.eu";
        public const string SML = "edelivery.tech.ec.europa.eu";
        public const string URL_SCHEME = "http://";
        public const string HASH_PREFIX = "b-";

        public RecepientID Recepient { get; internal set; }
        private Uri smlUrl;
        private String domainName;

        public Sml(string v)
        {
            this.Recepient = new RecepientID(v);
            domainName = HASH_PREFIX + Recepient.Hash + "." + Recepient.Scheme + "." + SML;
            smlUrl = new Uri( URL_SCHEME + domainName );
        }
        public override string ToString()
        {
            return "" + smlUrl;
        }

        public bool HostExists()
        {
            IPHostEntry host;
            bool ret = true;
            try {
                host = Dns.GetHostEntry(domainName);
            } catch (SocketException ex)
            {
                Console.WriteLine(ex.ErrorCode + " " + ex.SocketErrorCode);
                if ("HostNotFound".Equals(ex.SocketErrorCode.ToString()))
                {
                    ret = false;
                } else
                {
                    throw ex;
                }
            }
            return ret;
        }

    }
}