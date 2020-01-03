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

            var reply = client.CreateEmployee(new CreateEmployeeRequest
            {
                Employee = new Employee
                {
                    Id = "placeholder",
                    Person = new Person
                    {
                        Address = "Address",
                        BirthDate = DateTime.Now.ToString(),
                        EmailAddress = "Yeet@yeet.org",
                        FirstName = "Jenny",
                        Gender = Gender.Female,
                        LastName = "Johns",
                        PostalCode = "182838"
                    }
                }
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
