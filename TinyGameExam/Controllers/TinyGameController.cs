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

        private static readonly List<GameStage> GameStages = new List<GameStage>()
        {
            new GameStage{Stage = 1 , Question = new Question{ Id = 1 , ImageUrl = ""}, CountryId = 1} ,
            new GameStage{Stage = 2 , Question = new Question{ Id = 2 , ImageUrl = ""}, CountryId = 1},
            new GameStage{Stage = 3 , Question = new Question{ Id = 3 , ImageUrl = ""}, CountryId = 1},
            new GameStage{Stage = 4 , Question = new Question{ Id = 4 , ImageUrl = ""}, CountryId = 1},
            new GameStage{Stage = 5 , Question = new Question{ Id = 5 , ImageUrl = ""}, CountryId = 1},
            new GameStage{Stage = 6 , Question = new Question{ Id = 6 , ImageUrl = ""}, CountryId = 1},
            new GameStage{Stage = 7 , Question = new Question{ Id = 7 , ImageUrl = ""}, CountryId = 1},
            new GameStage{Stage = 8 , Question = new Question{ Id = 8 , ImageUrl = ""}, CountryId = 1},
            new GameStage{Stage = 9 , Question = new Question{ Id = 9 , ImageUrl = ""}, CountryId = 1},
            new GameStage{Stage = 10 , Question = new Question{ Id = 10 , ImageUrl = ""}, CountryId = 1}

        };

        private static readonly List<Country> Countrys = new List<Country>()
        {
            new Country{ Id=1 , Name = "Chinese"} ,
            new Country{ Id=1 , Name = "Japanese"} ,
            new Country{ Id=1 , Name = "Korean"} ,
            new Country{ Id=1 , Name = "Thai"}
        }; 

        public static Score Score { get; set; }

        public TinyGameController()
        {
            Score = new Score();
        }

        [HttpGet]
        [Route("/GetQuestion/{GameStage}")]
        public Question GetQuestion(int GameStage) => GameStages.First(x => x.Stage == GameStage).Question;


        [HttpGet]
        [Route("/GetScore")]
        public Score GetScore()
        {
           return Score;
        }

        [HttpGet]
        [Route("/StageResponse")]
        public EmptyResult StageResponse([FromBody]Response response)
        {
            var GameStage = GameStages.First(x => x.Stage == response.GameStage);
            if (GameStage.CountryId == response.CountryId) Score.RightAnswer(); else Score.WrongAnswer();            
            return new EmptyResult();

        }
    }
}