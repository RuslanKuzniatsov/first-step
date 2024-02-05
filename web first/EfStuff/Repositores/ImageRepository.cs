using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using web_first.EfStuff.DbModel;

namespace web_first.EfStuff.Repositores
{
    public class ImageRepository : BaseRepository<Image>
    {
        
        public ImageRepository(WebContext context) : base(context)
        {

        }

        
    }
}
