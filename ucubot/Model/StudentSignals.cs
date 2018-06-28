namespace ucubot.Model
{
    public class StudentSignals
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SignalType { get; set; }
        public int Count { get; set; }

        public override bool Equals(object obj)
        {
            var s = (StudentSignals) obj;
            return s.Count == Count
                   && s.FirstName == s.FirstName
                   && s.LastName == LastName
                   && s.SignalType == SignalType;
        }
    }
}
