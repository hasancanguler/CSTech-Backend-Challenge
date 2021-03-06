namespace BasketCore.Cashe
{
    public class RedisOption
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }
        public int Expires { get; set; }
    }
}
