using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Net;
using ucubot.Model;
using Dapper;
using ucubot.DBCode;

namespace ucubot.Controllers
{
    [Route("api/[controller]")]
    public class StudentEndpointController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentEndpointController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IEnumerable<Student> ShowStudents()
        {
            return _studentRepository.ShowStudentsN();
        }

        [HttpGet("{id}")]
        public Student ShowStudent(long id)
        {
            return _studentRepository.ShowStudentN(id);
        }

        [HttpPost]
        public async Task<HttpStatusCode> CreateStudent(Student student)
        {
            if (_studentRepository.CreateStudentN(student))
            {
                return HttpStatusCode.OK;
            }
            else{
                return HttpStatusCode.Conflict;
            }
        }

        [HttpPut]
        public async Task<HttpStatusCode> UpdateStudent(Student student)
        {
            if (_studentRepository.UpdateStudentN(student))
            {
                return HttpStatusCode.OK;
            }
            else{
                return HttpStatusCode.Conflict;
            }
        }

        [HttpDelete("{id}")]
        public async  Task<HttpStatusCode> RemoveStudent(long id)
        {
            if (_studentRepository.RemoveStudentN(id))
            {
                return HttpStatusCode.OK;
            }
            else{
                return HttpStatusCode.Conflict;
            }
        }
    }
}
