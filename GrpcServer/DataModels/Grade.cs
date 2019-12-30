using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.DataModels
{
    public class Grade
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime SchoolYear { get; set; }
        public List<Guid> GradeItems { get; set; }
    }
}
