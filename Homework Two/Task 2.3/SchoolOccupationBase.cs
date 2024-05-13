using Homework_2.Task_2._3.Contracts;

namespace Homework_2.Task_2._3
{
    public abstract class SchoolOccupationBase : ICloneable<SchoolOccupationBase>
    {
        public SchoolOccupationBase(string textDescription)
        {
            this.TextDescription = textDescription;
        }
        public string? TextDescription { get; set; }

        public abstract SchoolOccupationBase Clone();
    }
}
