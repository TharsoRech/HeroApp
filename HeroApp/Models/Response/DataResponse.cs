using HeroApp.Models.Entities;

namespace HeroApp.Models.Responser
{
    public class DataResponse
    {
        public int offset { get; set; }

        public int limit { get; set; }

        public int total { get; set; }

        public int count { get; set; }

        public List<Heroe> results { get; set; }
    }
}
