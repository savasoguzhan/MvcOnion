namespace MvcOnion.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string BookName { get; set; }

        //navigation

        public int AuthorId { get; set; }
        public Author  Author { get; set; }
    }
}