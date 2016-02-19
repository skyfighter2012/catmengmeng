using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatMM.Shared.Enums;

namespace CatMM.Domain.Students
{
    public class Student
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Sex
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Enrollment date
        /// </summary>
        public DateTime EnrollmentDate { get; set; }

        /// <summary>
        /// Enrollments
        /// </summary>
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
