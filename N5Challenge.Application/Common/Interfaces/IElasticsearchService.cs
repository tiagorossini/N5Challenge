namespace N5Challenge.Application.Common.Interfaces
{
    public interface IElasticsearchService<T>
    {
        Task<bool> CreateRegisterAsync(T document);
        Task<List<T>> GetAllRegistersAsync();
    }
}
