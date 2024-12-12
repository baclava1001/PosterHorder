namespace PosterHorder.Model
{
    public class SearchResult
    {
        [JsonProperty("page")]
        public int? Page { get; set; }

        [JsonProperty("results")]
        public List<Movie>? Results { get; set; }

        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int? TotalResults { get; set; }
    }
}
