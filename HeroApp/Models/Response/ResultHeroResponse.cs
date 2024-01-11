using HeroApp.Models.Responser;

namespace HeroApp.Models.Response
{
    public class ResultHeroResponse
    {
        public int Code { get; set; }

        public string Status { get; set; }

        public string copyright { get; set; }

        public string attributionText { get; set; }

        public string attributionHTML { get; set; }

        public string etag { get; set; }

        public DataResponse Data { get; set; }
    }

}
