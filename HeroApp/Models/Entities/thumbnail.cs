namespace HeroApp.Models.Entities
{
    public class Thumbnail
    {
        public string path { get; set; }

        public string extension { get; set; }

        public string image
        {
            get
            {
                return path.ToLower().Contains("https") ? $"{path}.{extension}" : $"{path.Replace("http", "https")}.{extension}";
            }
        }
    }
}
