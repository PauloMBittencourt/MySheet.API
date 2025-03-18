using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySheet.Domain.Entidades
{
    public class Usuarios
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public bool Status { get; set; }
    }
}
