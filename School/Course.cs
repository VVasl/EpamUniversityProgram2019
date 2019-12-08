namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaxStudents = 30;
        private List<Student> Students { get; set; } = new List<Student>();
        public static int Capacity
        {
            get { return Course.MaxStudents; }
        }

        private readonly SortedSet<Student> students = new SortedSet<Student>();

        public void AddStudents(Student student)
        {

            foreach (Student studentt in students)
            {
                if (!(this.students.Count < MaxStudents))
                    throw new ArgumentException("Course is full!");

                this.students.Add(student);
            }
        }

        public Course RemoveStudent(Student student)
        {
            this.students.Remove(student);

            return this;
        }
    }
}
