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
            Humans.HumansClient client = new Humans.HumansClient(channel);

            string guid = "2164e8d2-9f7e-4a4b-8bee-55d3bb32a3ae";

            var reply = client.EditEmployeeById(new EditEmployeeRequest
            {
                Employee = new Employee
                {
                    Id = guid,
                    Person = new Person
                    {
                        Address = "Address",
                        BirthDate = DateTime.Now.ToString(),
                        EmailAddress = "edited@edited.org",
                        FirstName = "Jenny",
                        Gender = Gender.Male,
                        LastName = "Johns",
                        PostalCode = "1010 AB"
                    }
                },
                EmployeeID = guid
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
