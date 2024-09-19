using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public Resource() {}

        public int ResourceId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        [Required]
        public string Url { get; set; } = null!;
        public enum ResourceType
        {
            Video,
            Presentation,
            Document,
            Other
        }

        [ForeignKey(nameof(Course))]
        public int CourseId {  get; set; }
        //[ForeignKey(nameof(CourseId)]
        public virtual Course Course { get; set; }
    }
}
