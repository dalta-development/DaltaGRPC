using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.DataModels
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Male = 0,
        Female = 1,
        Other = 2,
        Attack_Helicopter = 3
    }
}
