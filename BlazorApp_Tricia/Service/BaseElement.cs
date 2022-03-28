using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_Tricia.Service
{
    public class BaseElement
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public BaseElement()
        {
            _id = ObjectId.GenerateNewId();
        }
    }
}
