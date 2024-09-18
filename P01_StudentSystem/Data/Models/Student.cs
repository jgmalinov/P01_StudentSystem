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
        public int StudentID { get; set; }
        
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(10)"), StringLength(10)]
        public string PhoneNumber {  get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime Birthday { get; set; }

        // Navigation properties
        public ICollection<StudentCourse> StudentsCourses { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
    }
}
    