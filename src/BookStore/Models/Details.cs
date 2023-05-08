using BookStore.Data;

namespace BookStore.Models
{
    public class Details
    {
        public Details(Book book, string referer)
        {
            Book = book;
            Referer = referer;
        }
        public string Referer { get; private set; }
        public Book Book { get; private set; }
    }
}