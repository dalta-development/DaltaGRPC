using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.DataModels
{
    public class Employee : Person
    {
        [BsonId]
        public Guid Id { get; private set; } = Guid.NewGuid();
        public List<Role> Roles { get; set; }
    }

    public enum Role
    {
        EMPLOYEE = 0,
        ADMINISTRATOR = 1,
        IT_DEPARTMENT = 2
    }
}
