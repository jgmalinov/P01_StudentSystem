using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace P01_StudentSystem.Data.Models
{
    public partial class Student
    {
        // Columns
        public Student() 
        {
            StudentsCourses = new HashSet<StudentCourse>();
            Homeworks = new HashSet<Homework>();
        }
        [Key]
        public int StudentId { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; } = null!;

        [Column(TypeName = "varchar(10)"), StringLength(10)]
        public string? PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }

        // Navigation properties
        public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
    