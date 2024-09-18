﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course() 
        {
            StudentsCourses = new HashSet<StudentCourse>();
            Resources = new HashSet<Resource>();
            Homeworks = new HashSet<Homework>();
        }

        public int CourseID { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        [Required]
        public string Name { get; set; }
        public string Description {  get; set; }
        public DateTime StartDate {  get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        public ICollection<StudentCourse> StudentsCourses {  get; set; }
        //[ForeignKey(nameof(CourseID))]
        public ICollection<Resource> Resources {  get; set; }
        public ICollection<Homework> Homeworks { get; set; }
    }
}
