using static System.Net.Mime.MediaTypeNames;

namespace Projects.Model
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        
        public int CategoryId { get; set; }



    }
}
