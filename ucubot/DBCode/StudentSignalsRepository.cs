using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ucubot.Model;
using Dapper;

namespace ucubot.DBCode

{
    [Route("api/[controller]")]

    public class StudentSignalsEndpointN : IStudentSignalsRepository
    {
        private readonly IConfiguration _configuration;
        private readonly MySqlConnection _msqlConnection;
        private readonly string _connectionString;

        public StudentSignalsEndpointN(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("BotDatabase");
            _msqlConnection = new MySqlConnection(_connectionString);
        }

        public IEnumerable<StudentSignals> ShowStudentSignalsN()
        {
             try
             {
                _msqlConnection.Open();
                var comm = "SELECT first_name AS FirstName, last_name AS LastName, SignalType, Count FROM student_signals;";
                var lst = _msqlConnection.Query<LessonSignalDto>(comm).ToList();
                _msqlConnection.Close();
                return lst;
             }
             catch (Exception e)
             {
                 Console.WriteLine(e);
                 _msqlConnection.Close();
                 return null;
             }
        }
    }
}
