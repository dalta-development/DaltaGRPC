using Grpc.Net.Client;
using GrpcServer;
using System;

namespace GrpcTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            Employees.EmployeesClient client = new Employees.EmployeesClient(channel);

            string guid = "d5ce221c-5d4b-4746-8d2b-b1d6a613fd0f";

            //var reply = client.EditEmployeeById(new EditEmployeeRequest
            //{
            //    Employee = new Employee
            //    {
            //        Id = guid,
            //        Person = new Person
            //        {
            //            Address = "Address",
            //            BirthDate = DateTime.Now.ToString(),
            //            EmailAddress = "example@example.com",
            //            FirstName = "Jenny",
            //            Gender = Gender.Other,
            //            LastName = "Johns",
            //            PostalCode = "1010 AC"
            //        }
            //    },
            //    EmployeeID = guid
            //});

            var reply = client.GetEmployeeById(new GetEmployeeByIdRequest
            {
                Id = guid
            });

            if(reply.Employee == null)
            {
                Console.WriteLine("ERR_DB_ERROR");
            }
            else
            {
                Console.WriteLine(reply.Employee.ToString());
            }

            Console.ReadLine();
        }
    }
}
