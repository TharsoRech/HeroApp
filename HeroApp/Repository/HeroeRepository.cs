using Flurl;
using Flurl.Http;
using HeroApp.Helpers;
using HeroApp.Models.Response;
using System.Collections.Generic;

namespace HeroApp.Repository
{
    internal class HeroeRepository:IHeroeRepository
    {
        public async Task<ResultHeroResponse> GetHeroes(int limit,int offset,string filteredName = null)
        {
            try
            {
                List<Models.Entities.Heroe> list = new List<Models.Entities.Heroe>();
                for (int i = 0;i <4;i++)
                {
                    list.Add(new Models.Entities.Heroe
                            {
                                Id =1,
                                Name = "Iron Man " + i,
                                Thumbnail = new Models.Entities.Thumbnail
                                {
                                    Path = "https://cdn.marvel.com/content/1x/1078mob_ons_crd_01.jpg",
                                }
                            } );
                }
                return new ResultHeroResponse
                {

                    Data = new Models.Responser.DataResponse
                    {
                        Count = 0,
                        Limit = limit,
                        Offset = offset,
                        Total = 20,
                        Results = list
                    }
                };
                var url = string.IsNullOrEmpty(filteredName) ? $"characters?limit={limit}&offset={offset}" : $"characters?nameStartsWith={filteredName}&limit={limit}&offset={offset}";
                var response = await Urls.MarvelApiUrl
                    .AppendPathSegment($"{url}&apikey={Urls.ApiKey}")
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
