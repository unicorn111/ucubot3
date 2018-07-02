using System.Collections.Generic;
using ucubot.Model;

namespace ucubot.DBCode
{
    public interface IStudentSignalsRepository
    {
        IEnumerable<StudentSignals> ShowStudentSignalsN();
    }
}
