using N5Challenge.Application.Common.Interfaces;
using Nest;

namespace N5Challenge.Infrastructure.Services
{
    public class ElasticsearchService<T>(ElasticClient _elasticClient) : IElasticsearchService<T> where T : class
    {
        public async Task<bool> CreateRegisterAsync(T document)
        {
            var response = await _elasticClient.IndexDocumentAsync(document);

            return response.IsValid;
        }

        public async Task<List<T>> GetAllRegistersAsync()
        {
            var response = await _elasticClient.SearchAsync<T>(x => x.MatchAll().Size(10000));

            return response.Documents.ToList();
        }
    }
}
