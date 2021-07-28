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
    [Route("[controller]")]
    public class TinyGameController : ControllerBase
    {

        public TinyGameController()
        {
    
        }

        [HttpPost]
        public Question GetQuestion(int GameStageNumber )
        {
            return new Question();
        }

         public Score PostResponse(Response responce)
        {
            return new Score();
        }
    }


}