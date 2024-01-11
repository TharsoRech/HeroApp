using Flurl;
using Flurl.Http;
using HeroApp.Helpers;
using HeroApp.Models.Response;

namespace HeroApp.Repository
{
    internal class HeroeRepository:IHeroeRepository
    {
        public async Task<ResultHeroResponse> GetHeroes(int limit,int offset,string filteredName = null)
        {
            try
            {
                var url = string.IsNullOrEmpty(filteredName) ? $"limit={limit}&offset={offset}" : $"nameStartsWith={filteredName}&limit={limit}&offset={offset}";
                var response = await Urls.MarvelApiUrl
                    .AppendPathSegment($"characters?{url}&apikey={Urls.ApiKey}")
                    .GetAsync();

                if (response.ResponseMessage.IsSuccessStatusCode)
                {
                    var content = await response.ResponseMessage.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<ResultHeroResponse>(content);
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
