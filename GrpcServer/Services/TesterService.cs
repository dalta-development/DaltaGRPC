using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    [Authorize]
    public class TesterService : Tester.TesterBase
    {
        private readonly ILogger _logger;

        public TesterService(ILogger logger)
        {
            _logger = logger;
        }

        public override Task<TestReply> Test(TestRequest request, ServerCallContext context)
        {
            return Task.FromResult(new TestReply
            {
                Message = "Success"
            });
        }
    }
}
