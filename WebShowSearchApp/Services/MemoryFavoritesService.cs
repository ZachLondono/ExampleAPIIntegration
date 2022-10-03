using WebShowSearchApp.Models;

namespace WebShowSearchApp.Services;

public class InMemoryFavoritesService : IFavoritesService {

    private readonly HashSet<int> _favorites;

    public InMemoryFavoritesService() {
        _favorites = new();
    }

    public IReadOnlyList<int> GetFavorites() => _favorites.ToList();

    public void AddShowToFavorites(AddShowToFavoritesRequest request) {
        if (_favorites.Contains(request.ShowId)) return;
        _favorites.Add(request.ShowId);
    }

    public void RemoveShowFromFavorites(RemoveShowFromFavoritesRequest request) {
        _favorites.Remove(request.ShowId);
    }

}
