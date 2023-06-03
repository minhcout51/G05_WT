using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WT.Models
{
    public class Bill
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("TenSanPham")]
        public string Name { get; set; }
        [BsonElement("LoaiSanPham")]
        public string Category { get; set; }
        [BsonElement("SoLuong")]
       
        public int Quantity { get; set; }
      
        [BsonElement("ThanhTien")]
        public string TotalCost { get; set; }
        [BsonElement("NguoiMua")]
        public string Customer { get; set; }
        [BsonElement("TinhTrang")]
        public string Status { get; set; }
        [BsonElement("DonGia")]
        public string UnitPrice { get; set; }
    }
}