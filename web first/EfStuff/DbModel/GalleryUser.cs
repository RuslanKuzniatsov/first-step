using System;

namespace web_first.EfStuff.DbModel
{
    public class GalleryUser : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }

    }
}
