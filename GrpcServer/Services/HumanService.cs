using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStorage;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcServer
{
    public class HumanService : Humans.HumansBase
    {
        private readonly ILogger<HumanService> _logger;
        private readonly IDatabaseService _db;

        public HumanService(ILogger<HumanService> logger, IDatabaseService database)
        {
            _logger = logger;
            _db = database;
        }

        public override Task<GetEmployeeByIdReply> GetEmployeeById(GetEmployeeByIdRequest request, ServerCallContext context)
        {
            Person person = new Person{
                FirstName = "John",
                LastName = "Doe",
                Address = "Street",
                PostalCode = "9293912",
                EmailAddress = "email@example.com",
                BirthDate = DateTime.Now.ToString(),
                Gender = Gender.Male
            };

            Employee employee = new Employee
            {
                Person = person,
                UUID = Guid.NewGuid().ToString()
            };

            _db.StoreOne<Employee>(employee);

            return Task.FromResult(new GetEmployeeByIdReply
            {
                Employee = employee
            });

            
        }
    }
}
