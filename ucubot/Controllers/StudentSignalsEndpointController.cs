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
    public class StudentSignalsEndpointController : Controller
    {
        private readonly IStudentSignalsRepository _studentSignalsRepository;
        public StudentSignalsEndpointController(IStudentSignalsRepository studentSignalsRepository)
        {
            _studentSignalsRepository = studentSignalsRepository;
        }

        [HttpGet]
        public IEnumerable<StudentSignals> ShowSignals()
        {
            return _studentSignalsRepository.ShowStudentSignalsN();
        }
    }
}
