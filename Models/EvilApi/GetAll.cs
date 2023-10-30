using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EvilCompanies.Models.EvilApi
{
    public partial class GetAll
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("EvilLogo")]
        public string EvilLogo { get; set; }

        [JsonPropertyName("EvilPhone")]
        public string EvilPhone { get; set; }

        [JsonPropertyName("EvilWebsite")]
        public string EvilWebsite { get; set; }

        [JsonPropertyName("EvilLocation")]
        public string EvilLocation { get; set; }

        [JsonPropertyName("EvilCompanyName")]
        public string EvilCompanyName { get; set; }

        [JsonPropertyName("EvilnessRanking")]
        public string EvilnessRanking { get; set; }

        [JsonPropertyName("EvilTakeoverDate")]
        public string EvilTakeoverDate { get; set; }

        [JsonPropertyName("EvilWorldDominationPlan")]
        public string EvilWorldDominationPlan { get; set; }
    }
}