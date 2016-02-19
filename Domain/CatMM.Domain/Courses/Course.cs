using CatMM.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatMM.Domain.Courses
{
    /// <summary>
    /// Course
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Credits
        /// </summary>
        public int Credits { get; set; }

        /// <summary>
        /// Enrollments
        /// </summary>
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
