using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WT.Models
{
    public class Product
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [BsonElement("Ten")]
        public string Name { get; set; }
        [BsonElement("LoaiSanPham")]
        public string Category { get; set; }
        [BsonElement("ThuongHieu")]
        public string Brand { get; set; }
        [BsonElement("Gia")]
        public int Price { get; set; }
        [BsonElement("DoTuoi")]
        public string Age { get; set; }
        [BsonElement("HinhAnh")]
        public string Image { get; set; }
        
    }
   
}
