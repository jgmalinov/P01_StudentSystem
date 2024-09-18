using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext: DbContext
    {
        public StudentSystemContext() { }
        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options) { }
    }
}
