namespace School
{
    using System;
    using System.Collections.Generic;

    public class SchoolAdmissions
    {
        private readonly SortedSet<Student> students = new SortedSet<Student>();

        public SchoolAdmissions AddStudent(params Student[] students)
        {
            foreach (Student student in students)
            {
                if (this.students.Contains(student))
                    throw new ArgumentException("Student with duplicate ID!");

                this.students.Add(student);
            }

            return this;
        }
    }
}
