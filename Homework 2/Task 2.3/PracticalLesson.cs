namespace Homework_2.Task_2._3
{
    public class PracticalLesson : SchoolOccupationBase
    {
        public PracticalLesson(string textDescription,string? taskCondition, string? solution) : base(textDescription)
        {
            TaskCondition = taskCondition;
            Solution = solution;
        }

        public string? TaskCondition { get; set; }
        public string? Solution { get; set; }

        public override PracticalLesson Clone()
        {
            return new PracticalLesson(TextDescription, TaskCondition, Solution);
        }
    }
}
