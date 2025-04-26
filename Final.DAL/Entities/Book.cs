namespace Final.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string? Description { get; set; }

        public int Rating { get; set; }

        public ICollection<Loan> Loans { get; set; }
        
    }
}
