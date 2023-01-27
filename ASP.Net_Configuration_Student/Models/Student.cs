namespace ASP.Net_Configuration_Student.Models
{
    public class Student
    {
        public Profile? Profile { get; set; }
        public Academy? Academy { get; set; }
    }
    public class Profile
    {
        public string Firstname { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Age { get; set; }
        
    }
    public class Academy
    {
        public IEnumerable<string> Subjects { get; set; } = null!;
    }
}
