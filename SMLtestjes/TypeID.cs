using System;

namespace SMLtestjes
{
    internal class TypeID
    {
        public const string DEFAULT_TYPE = "0106";
        private string type;
        public static Iso6523SchemeIds isoSchemeIds = Iso6523SchemeIds.GetIso6523SchemeIds(); // new Iso6523SchemeIds();


        public TypeID()
        {
            this.type = DEFAULT_TYPE;
        }

        public TypeID(string type)
        {
            this.type = type;
            validate(this.type);
        }

        internal void validate(string participantID)
        {
            if (type == null || participantID == null || !isoSchemeIds.CheckIso6523(type))
                throw new TypeIDException();
        }
        public override string ToString()
        {
            return "" + type;
        }

    }
}