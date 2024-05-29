namespace Homework_6.ViewModels
{
    public class AuthorViewModel
    {
        public AuthorViewModel()
        {
            Books = new HashSet<BookViewModel>();   
        }

        public AuthorViewModel(string firstName, string lastName, DateOnly dateOfBirth) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public HashSet<BookViewModel> Books { get; set; }
    }
}
