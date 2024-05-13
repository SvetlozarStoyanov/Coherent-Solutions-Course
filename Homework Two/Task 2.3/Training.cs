
namespace Homework_2.Task_2._3
{
    public class Training
    {
        private SchoolOccupationBase[] classes;
        private int classesReachedIndex;
        public Training()
        {
            classes = new SchoolOccupationBase[0];
        }

        public Training(string? textDescription, SchoolOccupationBase[] classes) : this()
        {
            Classes = classes;
            TextDescription = textDescription;
        }

        public string? TextDescription { get; set; }

        public SchoolOccupationBase[] Classes
        {
            get { return classes; }
            private set { classes = value; }
        }

        public bool IsPractical()
        {
            if (Classes.Length == 0)
            {
                return false;
            }
            foreach (var classItem in Classes)
            {
                if (classItem is null)
                {
                    return true;
                }
                if (classItem is Lecture)
                {
                    return false;
                }
            }
            return true;
        }

        public void Add(SchoolOccupationBase classItem)
        {
            if (classesReachedIndex >= Classes.Length)
            {
                ResizeClassesArray();
            }
            Classes[classesReachedIndex++] = classItem;
        }

        private void ResizeClassesArray()
        {
            var oldSize = Classes.Length == 0 ? 1 : Classes.Length; 
            var result = new SchoolOccupationBase[oldSize * 2];
            for (int i = 0; i < Classes.Length; i++)
            {
                result[i] = Classes[i];
            }
            Classes = result;
        }

        public Training Clone()
        {
            var clone = new Training();
            clone.TextDescription = this.TextDescription;
            foreach (var classItem in Classes)
            {
                if (classItem == null)
                {
                    break;
                }
                clone.Add(classItem);
            }
            return clone;
        }
    }
}
