namespace StudentSystem.Core
{
    public abstract class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Gender Gender { get; set; }

        public abstract string Sleep();
    }
}