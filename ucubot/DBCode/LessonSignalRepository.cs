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

    public class LessonSignalEndpointN : ILessonSignalRepository
    {
        private readonly IConfiguration _configuration;
        private readonly MySqlConnection _msqlConnection;
        private readonly string _connectionString;

        public LessonSignalEndpointN(IConfiguration configuration)

        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("BotDatabase");
            _msqlConnection = new MySqlConnection(_connectionString);
        }

        public IEnumerable<LessonSignalDto> ShowSignalsN()
        {
            try
            {
                _msqlConnection.Open();
                var comm = "SELECT lesson_signal.Id as Id, lesson_signal.Timestemp as Timestamp, " +
                        "lesson_signal.signal_type as Type, student.user_id as UserId FROM lesson_signal" +
                        " JOIN student ON lesson_signal.student_id = student.id;";
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

        public LessonSignalDto ShowSignalN(long id)
        {
            try
            {
                _msqlConnection.Open();
                var comm = "SELECT lesson_signal.Id as Id, lesson_signal.Timestemp as Timestamp, " +
                        "lesson_signal.signal_type as Type, student.user_id as UserId FROM lesson_signal" +
                        " JOIN student ON lesson_signal.student_id = student.id WHERE lesson_signal.Id = @id;";
                var signalDto = _msqlConnection.Query<LessonSignalDto>(comm).ToList();
                _msqlConnection.Close();
                return signalDto.First();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _msqlConnection.Close();
                return null;
            }
        }

        public bool CreateSignalN(SlackMessage message)
        {
            try
                {
                    _msqlConnection.Open();
                    var userId = message.user_id;
                    var signalType = message.text.ConvertSlackMessageToSignalType();
                    var comm = "SELECT id as Id, first_name as FirstName, last_name as LastName, user_id as UserId from student where user_id=@uId";
                    _msqlConnection.Query<Student>(comm, new {uId = userId}).AsList(););
                    if (!stds.Any())
                    {
                        _msqlConnection.Close();
                        return false;
                    }
                    var comm2 = "INSERT INTO lesson_signal (student_id, signal_type) VALUES (@std, @st)";
                    connection.Execute(comm2, new {std = stds[0].Id, st = signalType});
                    _msqlConnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    _msqlConnection.Close();
                    return false;
                }

        }

        public bool RemoveSignalN(long id)
        {
            _msqlConnection.Open();
            try
            {
                var com = "DELETE FROM lesson_signal WHERE id=@id;";
                _msqlConnection.Execute(com, new {Id = id});
                _msqlConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _msqlConnection.Close();
                return false;
            }
        }
    }
}
