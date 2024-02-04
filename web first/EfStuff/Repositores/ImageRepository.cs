using System.Collections.Generic;
using System.Linq;
using web_first.EfStuff.DbModel;

namespace web_first.EfStuff.Repositores
{
    public class ImageRepository
    {
        private WebContext _context;

        public ImageRepository(WebContext context)
        {
           _context = context;
        }

        public List<> GetAll ()
        {
            return _context.Images.ToList();
        }

        public Image Get(int id)
        {
            return _context.Images.FirstOrDefault(x => x.Id == id);
        }
    }
}
