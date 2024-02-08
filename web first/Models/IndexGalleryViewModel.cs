using System.Collections.Generic;

namespace web_first.Models
{
    public class IndexGalleryViewModel
    {
        public int Page { get; set; }
        public List<ImageViewModel> Images { get; set; }
    }
}
