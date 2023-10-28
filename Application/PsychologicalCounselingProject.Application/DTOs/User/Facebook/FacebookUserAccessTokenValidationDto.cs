using System.Text.Json.Serialization;

namespace PsychologicalCounselingProject.Application.DTOs.User.Facebook
{
    public class FacebookUserAccessTokenValidationDto
    {
        [JsonPropertyName("data")]
        public FacebookUserAccessTokenValidationData Data { get; set; }
    }
}
