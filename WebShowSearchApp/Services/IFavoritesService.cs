using WebShowSearchApp.Models;

namespace WebShowSearchApp.Services;

public interface IFavoritesService {

    public IReadOnlyList<int> GetFavorites();

    public void AddShowToFavorites(AddShowToFavoritesRequest request);

    public void RemoveShowFromFavorites(RemoveShowFromFavoritesRequest request);

}