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

            var reply = client.GetEmployeeById(new GetEmployeeByIdRequest
            {
                Id = "qrr"
            });

            if(reply.Employee == null)
            {
                Console.WriteLine("ERR_WRONG_UUID");
            }
            else
            {
                Console.WriteLine(reply.Employee.ToString());
            }

            Console.ReadLine();
        }
    }
}
