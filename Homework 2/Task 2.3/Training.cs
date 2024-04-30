namespace Homework_2.Task_2._3
{
    public class Training
    {
        private HashSet<ParentClass> classes;

        public Training()
        {
            classes = new HashSet<ParentClass>();
        }

        public Training(string? textDescription, HashSet<ParentClass> classes) : this()
        {
            Classes = classes;
            TextDescription = textDescription;
        }

        public string? TextDescription { get; set; }

        public HashSet<ParentClass> Classes
        {
            get { return classes; }
            private set { classes = value; }
        }

        public bool IsPractical()
        {
            if (Classes.Count == 0)
            {
                return false;
            }
            foreach (var classItem in Classes)
            {
                if (classItem is Lecture)
                {
                    return false;
                }
            }
            return true;
        }

        public void Add(ParentClass classItem)
        {
            Classes.Add(classItem);
        }

        public Training Clone()
        {
            var clone = new Training();
            clone.TextDescription = this.TextDescription;
            foreach (var classItem in Classes)
            {
                clone.Classes.Add(classItem.Clone());
            }
            return clone;
        }
    }
}
