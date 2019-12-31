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
            var client = new Humans.HumansClient(channel);

            var reply = client.GetEmployeeById(new GetEmployeeByIdRequest
            {
                UUID = "Nice"
            });

            Console.WriteLine(reply.Employee.UUID);

            Console.ReadLine();
        }
    }
}
