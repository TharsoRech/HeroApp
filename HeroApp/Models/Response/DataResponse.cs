using HeroApp.Models.Entities;

namespace HeroApp.Models.Responser
{
    public class DataResponse
    {
        public int Offset { get; set; }

        public int Limit { get; set; }

        public int Total { get; set; }

        public int Count { get; set; }

        public List<Heroe> Results { get; set; }
    }
}
