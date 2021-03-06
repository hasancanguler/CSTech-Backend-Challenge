using System.Net.Http;
using System.Threading.Tasks;

namespace APIConnection
{
    public interface IAPIConnect
    {
        Task<HttpResponseMessage> Get(string url);
    }
}
