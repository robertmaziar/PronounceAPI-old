namespace PronounceAPI.Models
{
    public class PronounceAPIDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string WordsCollectionName { get; set; } = null!;
    }
}
