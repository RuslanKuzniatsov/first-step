using System.Linq;
using web_first.EfStuff.DbModel;

namespace web_first.EfStuff.Repositores
{
    public class GalleryUserRepository : BaseRepository<GalleryUser>
    {
        public GalleryUserRepository(WebContext context) : base(context)
        {
        }
        public GalleryUser GetByNameAndPass(string name, string password)
        {
            var user = _webContext.GalleryUsers.Single(x => x.Name == name && x.Password == password);
            return user;
        }
        
    }
}
