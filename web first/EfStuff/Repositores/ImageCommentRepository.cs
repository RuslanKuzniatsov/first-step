using web_first.EfStuff.DbModel;

namespace web_first.EfStuff.Repositores
{
    public class ImageCommentRepository : BaseRepository<ImageComment>
    {
        
        public ImageCommentRepository(WebContext context):base(context)
        {
            
        }
        
    }
}
