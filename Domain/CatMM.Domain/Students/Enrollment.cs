using CatMM.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Domain.Students
{
    /// <summary>
    /// Enrollment
    /// </summary>
    public class Enrollment
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Student id
        /// </summary>
        public string StudentId { get; set; }

        /// <summary>
        /// Course id
        /// </summary>
        public string CourseId { get; set; }

        /// <summary>
        /// Student
        /// </summary>
        public virtual Student Student { get; set; }

        /// <summary>
        /// Course
        /// </summary>
        public virtual Course Course { get; set; }

        /// <summary>
        /// Grade
        /// </summary>
        public decimal? Grade { get; set; }
    }
}
