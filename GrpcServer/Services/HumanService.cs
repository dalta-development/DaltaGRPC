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
            bool parseGuid = Guid.TryParse(request.Id, out var result);
            if(parseGuid == true)
            {
                var employee = _db.FindOne<Employee>(x => x.Id == request.Id);

                var employeeReply = new GetEmployeeByIdReply
                {
                    Employee = employee.Result
                };

                return Task.FromResult(employeeReply);
            }
            else
            {
                return Task.FromResult(new GetEmployeeByIdReply
                {
                    Employee = null
                });
            }
        }
    }
}
