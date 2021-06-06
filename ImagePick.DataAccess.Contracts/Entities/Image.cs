namespace ImagePick.DataAccess.Contracts.Entities
{
    public class Image
    {
        
        public string Id { get; set; }

        public string RegularUrl { get; set; }

        public string SmallUrl { get; set; }

        public string ThumbUrl { get; set; }

        public string UserName { get; set; }

        public string UserProfileImageSmall { get; set; }

        public string UserHtmlLink { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }


    }
}
