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
    public class LessonSignalEndpointController : Controller
    {
        private readonly ILessonSignalRepository _lessonSignalRepository;

        public LessonSignalEndpointController(ILessonSignalRepository lessonSignalRepository)
        {
            _lessonSignalRepository = lessonSignalRepository;
        }

        [HttpGet]
        public IEnumerable<LessonSignalDto> ShowSignals()
        {
            return _lessonSignalRepository.ShowSignalsN();
        }

        [HttpGet("{id}")]
        public LessonSignalDto ShowSignal(long id)
        {
            return _lessonSignalRepository.ShowSignalN(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSignal(SlackMessage message)
        {
            if (_lessonSignalRepository.CreateSignalN(message))
            {
                return Accepted();
            }
            else{
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSignal(long id)
        {
            if ( _lessonSignalRepository.RemoveSignalN(id))
                {
                    return Accepted();
                }
                else{
                    return BadRequest();
                }
        }
    }
}
