using System.Collections.Generic;
using ucubot.Model;

namespace ucubot.DBCode
{
    public interface IStudentSignals
    {
        IEnumerable<StudentSignals> ShowSignalsN();
    }
}
