using System;
using System.Security.Cryptography;
using System.Text;

namespace SMLtestjes
{
    internal class RecepientID
    {
        public const char SEP = ':';
        public const string RECEPIENT_SCHEME = "iso6523-actorid-upis";

        private TypeID typeID;
        private string participantID;

        public string Hash { get; internal set; }
        public string Scheme { get; internal set; } = RECEPIENT_SCHEME;

        public RecepientID(string v)
        {
            Parse(v);
        }

        public override string ToString()
        {
            return ""+typeID+SEP+participantID;
        }

        public void Parse(string v)
        {
            var parts = v.Split(SEP);
            if (parts.Length >= 2)
            {
                if (parts[0].Length > 1)
                {
                    typeID = new TypeID(parts[0]);
                }
                else
                {
                    typeID = new TypeID();
                }
                participantID = parts[1];
            }
            else
            {
                typeID = new TypeID();
                participantID = v;
            }
            typeID.validate(participantID);
            Hash = CalculateMD5Hash(this.ToString());
        }

        public string CalculateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input.ToLower());
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

    }
}