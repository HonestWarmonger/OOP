namespace FishingStoreApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public Customer(int id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }
    }
}