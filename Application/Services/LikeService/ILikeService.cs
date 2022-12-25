namespace Application.Services.LikeService;

public interface ILikeService
{
    public Task<List<long>> GetLikedProfileIds(long userId);
}