namespace Application.Services.DislikeService;

public interface IDislikeService
{
    public Task<List<long>> GetDislikedProfileIds(long userId);
}