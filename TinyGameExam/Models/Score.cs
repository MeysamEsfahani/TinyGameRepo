namespace TinyGameExam.Models
{
    public class Score
    {
        const int RightAnswerReward = 20;

        const int WrongAnswerCost = -5;
        public int CountRightAnswer  { get; private set; }

        public int CountWrongAnswer  { get; private set; }

        public int YourScore => (CountRightAnswer*RightAnswerReward)+(CountWrongAnswer*WrongAnswerCost);

        public Score()
        {
            CountRightAnswer = 0;
            CountWrongAnswer = 0;
        }

        public void RightAnswer() => CountRightAnswer++;
        public void WrongAnswer() => CountWrongAnswer++;


    }
}