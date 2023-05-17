using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace WT.Models
{
    public class Employee
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("HoTen")]
        public string FullName { get; set; }
        [BsonElement("SDT")]
        public int PhoneNumber { get; set; }
        [BsonElement("CongViec")]
        public string Job { get; set; }
        [BsonElement("NgaySinh")]
        public string DateOfBirth { get; set; }
    }
}