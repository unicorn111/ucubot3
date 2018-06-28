using System.Collections;
using System.Collections.Generic;
using ucubot.Model;
namespace ucubot.DBCode
{
    public interface IStudentRepository
    {
        IEnumerable<Student> ShowStudentsN();
        Student ShowStudentN(long id);
        bool CreateStudentN(Student student);
        bool UpdateStudentN(Student student);
        bool RemoveStudentN(long id);

    }
}
