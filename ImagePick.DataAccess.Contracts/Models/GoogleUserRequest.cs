namespace ImagePick.DataAccess.Contracts.Models
{
    public class GoogleUserRequest
    {
        public const string PROVIDER = "google";

        public string IdToken { get; set; }
    }
}
