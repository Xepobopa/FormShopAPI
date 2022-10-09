using Dapper.Contrib.Extensions;

namespace WebAPI.Models
{
    [Table("Product")]
    public class Product
    {
        public Product(int Id, string Name, int Price, int Category_key)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Category_key = Category_key;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Category_key { get; set; }
    }

}
