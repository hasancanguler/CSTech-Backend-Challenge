namespace BasketCore.Cashe
{
    public interface ICasheService
    {
        T Get<T>(string key);
        void Set<T>(string key, T data);
    }
}
