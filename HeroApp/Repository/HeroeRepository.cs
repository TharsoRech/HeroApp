using Flurl;
using Flurl.Http;
using HeroApp.Helpers;
using HeroApp.Models.Response;
using RestSharp;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace HeroApp.Repository
{
    internal class HeroeRepository:IHeroeRepository
    {
        public async Task<ResultHeroResponse> GetHeroes(int limit,int offset,string filteredName = null)
        {
            try
            {
                var ts = DateTime.Now.Ticks.ToString();
                var hash = SessionsHelper.GerarHash(ts ,Urls.ApiKeyPublic ,Urls.ApiKeyPrivate);
                var url = string.IsNullOrEmpty(filteredName) ? $"limit={limit}&offset={offset}" : $"nameStartsWith={filteredName}&limit={limit}&offset={offset}";

                var client = new RestClient(Urls.MarvelApiUrl);
                var request = new RestRequest($"characters?{url}&ts={ts}&apikey={Urls.ApiKeyPublic}&hash={hash}");
                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<ResultHeroResponse>(response.Content);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           return null;
        }
    }
}
