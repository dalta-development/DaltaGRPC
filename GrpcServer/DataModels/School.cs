using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.DataModels
{
    public class School
    {
        [BsonId]
        public Guid Id { get; private set; } = Guid.NewGuid();
        public List<Guid> StudentUUIDs;
    }
}
