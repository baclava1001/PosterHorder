
namespace PosterHorder.Services
{
    public interface ISavePosterService
    {
        Task SavePosterAsync(string imageUrl, string fileName);
    }
}