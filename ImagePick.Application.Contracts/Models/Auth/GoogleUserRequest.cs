using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ImagePick.Application.Contracts.Models.Auth
{
    public class GoogleUserRequest
    {
        public const string PROVIDER = "google";

        [JsonProperty("idToken")]
        [Required]
        public string IdToken { get; set; }
    }
}
