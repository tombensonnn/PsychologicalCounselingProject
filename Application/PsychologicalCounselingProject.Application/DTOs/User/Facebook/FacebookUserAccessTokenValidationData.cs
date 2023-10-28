using System.Text.Json.Serialization;

namespace PsychologicalCounselingProject.Application.DTOs.User.Facebook
{
    public class FacebookUserAccessTokenValidationData
    {
        [JsonPropertyName("is_valid")]
        public bool IsValıd { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
