using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;

namespace SMLtestjes
{
    public class Iso6523SchemeIds //: ICollection
    {
        // https://www.galaxygw.com/iso6523/

        private Hashtable iso6523List = new Hashtable();
        private Hashtable schemeIdList = new Hashtable();

        private static Iso6523SchemeIds _iso6523SchemeIds;
        public ArrayList isoSchemeList = new ArrayList();



        public static Iso6523SchemeIds GetIso6523SchemeIds()
        {
            if (_iso6523SchemeIds == null )
            {
                _iso6523SchemeIds = new Iso6523SchemeIds();
            }
            return _iso6523SchemeIds;
        }

        internal bool CheckIso6523(string type)
        {
            //isoSchemeList.;
            return true;
        }

        public Iso6523SchemeIds()
        {
            loadFromAssembly();
            Iso6523SchemeId isi = new Iso6523SchemeId()
            {
                Iso6523 = "9953",
                SchemId = "VA:VAT",
                Name = "Holy See(Vatican City State) VAT number"
            };
            iso6523List.Add(isi.Iso6523, isi);
            schemeIdList.Add(isi.SchemId, isi);
            isoSchemeList.Add(isi);
        }

        private void loadFromAssembly()
        {
            var txt = SMLtestjes.Properties.Resources.Iso6523SchemeIds;
            using (StringReader sr = new StringReader(txt))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    //Console.WriteLine($"Line[{++i} = {line}");
                    var splited = Regex.Split(line, "([0-9]+)[\t ]([A-Z:]+)[\t ](.+)");
                    Iso6523SchemeId isi = new Iso6523SchemeId()
                    {
                        Iso6523 = splited[1],
                        SchemId = splited[2],
                        Name = splited[3]
                    };
                    isoSchemeList.Add(isi);
                }
            }
        }
    }
}