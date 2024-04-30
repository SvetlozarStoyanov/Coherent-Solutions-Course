namespace Homework_2.Task_2._3
{
    public abstract class ParentClass
    {
        public ParentClass(string textDescription)
        {
            this.TextDescription = textDescription;
        }
        public string? TextDescription { get; set; }

        public abstract ParentClass Clone();
    }
}
