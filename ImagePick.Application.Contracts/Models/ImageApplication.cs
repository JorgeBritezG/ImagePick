using System.ComponentModel.DataAnnotations;

namespace ImagePick.Application.Contracts.Models
{
    public class ImageApplication
    {
        public int Id { get; set; }

        public string RegularUrl { get; set; }

        public string SmallUrl { get; set; }

        public string ThumbUrl { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        public string UserProfileImageSmall { get; set; }

        public string UserHtmlLink { get; set; }

        public int AlbumId { get; set; }

        public AlbumApplication Album { get; set; }
    }
}
