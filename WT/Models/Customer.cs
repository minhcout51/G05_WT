using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WT.Models
{
    public class Customer
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("HoTen")]
        public string FullName { get; set; }
        [BsonElement("SDT")]
        public int PhoneNumber { get; set; }
        [BsonElement("DiaChi")]
        public string Address { get; set; }
        [BsonElement("Username")]
        public string Username { get; set; }
       [BsonElement("MatKhau")]
       public string Password { get; set; }
    }
}