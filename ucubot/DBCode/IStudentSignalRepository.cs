using System.Collections.Generic;
using ucubot.Model;

namespace ucubot.DBCode
{
    public interface IStudentSignal
    {
        IEnumerable<StudentSignal> ShowSignalsN();
    }
}
