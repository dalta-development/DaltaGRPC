using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStorage;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcServer
{
    public class EmployeeService : Employees.EmployeesBase
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly IDatabaseService _db;

        public EmployeeService(ILogger<EmployeeService> logger, IDatabaseService database)
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

        public override Task<CreateEmployeeReply> CreateEmployee(CreateEmployeeRequest request, ServerCallContext context)
        {
            try
            {
                request.Employee.Id = Guid.NewGuid().ToString();
                _db.StoreOne(request.Employee);
                return Task.FromResult(new CreateEmployeeReply
                {
                    Employee = request.Employee
                });
            }
            catch(Exception e)
            {
                return Task.FromResult(new CreateEmployeeReply
                {
                    Employee = null
                });
            }
        }

        public override Task<EditEmployeeReply> EditEmployeeById(EditEmployeeRequest request, ServerCallContext context)
        {
            _db.UpdateOne<Employee>(x => x.Id == request.EmployeeID, request.Employee);
            return Task.FromResult(new EditEmployeeReply
            {
                Employee = request.Employee
            });
        }
    }
}
