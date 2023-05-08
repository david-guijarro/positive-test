using Kontent.Ai.Delivery.Abstractions;
using Kontent.Ai.Urls.Delivery.QueryParameters;

namespace BookStore.Services
{
    public class KontentAIClient : IKontentAIClient
    {
        private readonly IDeliveryClient _deliveryClient;

        public KontentAIClient(IDeliveryClient deliveryClient)
        {
            _deliveryClient = deliveryClient;
        }

        public async Task<IDeliveryItemListingResponse<T>> GetItemsAsync<T>(int skip = 0, int limit = 10)
        {
            var response = await _deliveryClient.GetItemsAsync<T>(GetPaginationParameters(skip, limit));
            ResponseGuard(response);
            return response;
        }

        public async Task<IDeliveryItemResponse<T>> GetItemAsync<T>(string codename)
        {
            var response = await _deliveryClient.GetItemAsync<T>(codename);
            ResponseGuard(response);
            return response;
        }

        private static IQueryParameter[] GetPaginationParameters(int skip, int limit)
        {
            return new IQueryParameter[]
            {
                new SkipParameter(skip),
                new LimitParameter(limit),
                new IncludeTotalCountParameter()
            };
        }

        private static void ResponseGuard(IResponse response)
        {
            if (!response.ApiResponse.IsSuccess)
                throw new InvalidOperationException(response.ApiResponse.Error.Message);
        }
    }
}