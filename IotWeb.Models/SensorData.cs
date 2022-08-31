using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IotWeb.Models
{
    public class SensorData
    {
        [BsonId]
        public ObjectId _Id { get; set; }
        public int Humidity { get; set; }
        public int Temprature { get; set; }
    }
}
