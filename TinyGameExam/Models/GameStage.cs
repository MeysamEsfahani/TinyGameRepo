using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyGameExam.Models
{
    public class GameStage
    {
        public int Stage { get; set; }

        public Question Question { get; set; }

        public int CountryId { get; set; }
    }
}
