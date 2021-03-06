using System.Net.Http;
using System.Threading.Tasks;

namespace APIConnection
{
    public class APIConnect : IAPIConnect
    {
        private string _baseUrl;
        public APIConnect(string APIBaseUrl)
        {
            _baseUrl = APIBaseUrl;
        }

        public async Task<HttpResponseMessage> Get(string url)
        {
            Task<HttpResponseMessage> responseMessage;

            using (var client = new HttpClient())
            {
                responseMessage = client.GetAsync(_baseUrl + url);
                responseMessage.Wait();
                var result = responseMessage.Result;
                if (!result.IsSuccessStatusCode)
                {
                    //There can be some log
                }
            }
            return await responseMessage;
        }
    }
}
