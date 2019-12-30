using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.DataModels
{
    public class GradeItem
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public float NumberGrade { get; set; } = 0.0F;
        public char LetterGrade { get; set; }
        public int Weight { get; set; } = 1;
        public DateTime DateGiven { get; private set; } = DateTime.Now;
        public bool IsLetterGrade { get; set; }
        public Employee Teacher { get; set; }
        public Employee Surveillant { get; set; }
    }
}
