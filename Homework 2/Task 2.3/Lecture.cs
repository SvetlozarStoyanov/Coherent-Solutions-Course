namespace Homework_2.Task_2._3
{
    public class Lecture : SchoolOccupationBase
    {
        public string? Topic { get; set; }

        public Lecture(string textDescription, string? topic) : base(textDescription)
        {
            Topic = topic;
        }

        public override SchoolOccupationBase Clone()
        {
            return new Lecture(TextDescription, Topic);
        }
    }
}
