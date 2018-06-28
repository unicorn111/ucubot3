using System.Collections;
using System.Collections.Generic;
using ucubot.Model;
namespace ucubot.DBCode
{
     public interface ILessonSignalRepository
    {
        IEnumerable<LessonSignalDto> ShowSignalsN();
        LessonSignalDto ShowSignalN(long id);
        bool CreateSignalN(SlackMessage message);
        bool RemoveSignalN(long id);
    }
}
