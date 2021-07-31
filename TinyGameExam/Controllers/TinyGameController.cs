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
            new GameStage{Stage = 1 , Question = new Question{ Id = 1 , ImageUrl = "Images/j1.jpg"}, CountryId = 2} ,
            new GameStage{Stage = 2 , Question = new Question{ Id = 2 , ImageUrl = "Images/CH3.jpg"}, CountryId = 1},
            new GameStage{Stage = 3 , Question = new Question{ Id = 3 , ImageUrl = "Images/j2.jpg"}, CountryId = 2},
            new GameStage{Stage = 4 , Question = new Question{ Id = 4 , ImageUrl = "Images/KO1.jpg"}, CountryId = 3},
            new GameStage{Stage = 5 , Question = new Question{ Id = 5 , ImageUrl = "Images/KO3.jpg"}, CountryId = 3},
            new GameStage{Stage = 6 , Question = new Question{ Id = 6 , ImageUrl = "Images/j3.jpg"}, CountryId = 2},
            new GameStage{Stage = 7 , Question = new Question{ Id = 7 , ImageUrl = "Images/CH2.jpg"}, CountryId = 1},
            new GameStage{Stage = 8 , Question = new Question{ Id = 8 , ImageUrl = "Images/j4.jpg"}, CountryId = 2},
            new GameStage{Stage = 9 , Question = new Question{ Id = 9 , ImageUrl = "Images/j5.jpg"}, CountryId = 2},
            new GameStage{Stage = 10 , Question = new Question{ Id = 10 , ImageUrl = "Images/CH1.jpg"}, CountryId = 1}

        };

        private static readonly List<Country> Countries = new List<Country>()
        {
            new Country{ Id=1 , Name = "Chinese"} ,
            new Country{ Id=2 , Name = "Japanese"} ,
            new Country{ Id=3 , Name = "Korean"} ,
            new Country{ Id=4 , Name = "Thai"}
        };

       
        public  Score Score { get; set; }

        public TinyGameController(Score score)
        {
            Score = score;
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

        [HttpPost]
        [Route("/StageResponse")]
        public void StageResponse([FromBody] Answer answer)
        {
            var GameStage = GameStages.First(x => x.Stage == answer.GameStage);
            if (GameStage.CountryId == answer.CountryId) 
                Score.RightAnswer();
            else 
                Score.WrongAnswer();
        }

        [HttpGet]
        [Route("/Countries")]
        public List<Country> getCountries()
        {
            return Countries.OrderBy(x => x.Name).ToList();
        }
        [HttpGet]
        [Route("/ScoreReset")]
        public void ScoreReset()
        {
            Score.Reset();
        }
    }
}