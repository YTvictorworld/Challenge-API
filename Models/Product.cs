using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Full.Stack.WebDev.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("product_name")]
        public string Name { get; set; }
        [Column("product_code")]
        public string ProductCode { get; set; }
        [Column("product_price")]
        public int ProductPrice { get; set; }
    }
}
