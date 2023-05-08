using BookStore.Data;
using Kontent.Ai.Delivery.Abstractions;

namespace BookStore.Models
{
    public class Home
    {
        public Home(IDeliveryItemListingResponse<Book> clientResponse, int maxItems)
        {
            Books = clientResponse.Items;
            Pagination = new Pagination(clientResponse, maxItems);
        }

        public IEnumerable<Book> Books { get; private set; }
        public Pagination Pagination { get; private set; }
    }
}