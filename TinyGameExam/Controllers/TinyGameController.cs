using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyGameExam.Models;

namespace TinyGameExam.Controllers
{
    [ApiController]
    [Route("[tinyGame]")]
    public class TinyGameController : ControllerBase
    {
        public TinyGameController()
        {

        }

        [HttpGet]
        [Route("/GetQuestion/{GameStage}")]
        public Question GetQuestion(int GameStage)
        {
            return new Question()
            {
                Id = 1,
                ImageUrl = $"../Images/j1.jpg"
            };
        }
    }
}