namespace TinyGameExam.Models
{
    public class Score
    {
        const int RightAnswerReward = 20;

        const int WrongAnswerCost = -5;
        public int CountRightAnswer  { get; set; }

        public int CountWrongAnswer  { get; set; }

        public int YourScore => CountRightAnswer*RightAnswerReward-CountWrongAnswer*WrongAnswerCost;

    }
}