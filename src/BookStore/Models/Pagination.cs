using BookStore.Data;
using Kontent.Ai.Delivery.Abstractions;

namespace BookStore.Models
{
    public class Pagination
    {
        public Pagination(IDeliveryItemListingResponse<Book> clientResponse, int maxItems)
        {
            ResultsCount = clientResponse.Pagination.TotalCount ?? 0;
            CurrentPage = (clientResponse.Pagination.Skip / maxItems) + 1;
            PagesCount = (int)Math.Ceiling((double)ResultsCount / maxItems);
        }
        public int ResultsCount { get; private set; }
        public int CurrentPage { get; private set; }
        public int PagesCount { get; private set; }
    }
}