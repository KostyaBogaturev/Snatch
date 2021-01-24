using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using System.Net.Http;

namespace snatch
{
    using Helper;
    using System.Threading.Tasks;

    class HttpClientWrapper
    {
        IStateConverter jsonStateConverter = new JsonStateConverter();

        public async Task<TRes> GetAsync<TRes>(string url)
        {

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(url);

                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content?.ReadAsStringAsync();
                    //IStateConverter stateConverter = jsonStateConverter;
                    return jsonStateConverter.From<TRes>(response);
                }

                return default(TRes);
            }
        }

        public async Task<string> GetAsync(string url)
        {

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(url);

                if (result.IsSuccessStatusCode)
                {
                    return await result.Content?.ReadAsStringAsync();
                }

                return null;
            }
        }
    }
}
