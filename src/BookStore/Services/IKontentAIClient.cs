using Kontent.Ai.Delivery.Abstractions;

namespace BookStore.Services
{
    public interface IKontentAIClient
    {
        Task<IDeliveryItemListingResponse<T>> GetItemsAsync<T>(int skip, int limit);
        Task<IDeliveryItemResponse<T>> GetItemAsync<T>(string codename);
    }
}