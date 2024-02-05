namespace web_first.EfStuff.DbModel
{
    public class ImageComment : BaseModel
    {
        
        public virtual Image Image { get; set; }
        
        public string Text { get; set; }
    }
}
