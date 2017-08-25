namespace SMLtestjes
{
    internal class ParticipantIdentifier
    {
        private string _participantIdentifier;
        public string Identifier {
            get { return _participantIdentifier; }
            set { _participantIdentifier = value; }
        }

        public ParticipantIdentifier(string participantIdentifier)
        {
            this._participantIdentifier = participantIdentifier;
        }
    }
}