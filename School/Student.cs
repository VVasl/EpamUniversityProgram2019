namespace School
{
    using System;

    public class Student : IComparable<Student>
    {
        public const int MinId = 10000;

        public const int MaxId = 99999;

        private string name = null;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException($"{Name}");

                this.name = value;
            }
        }

        private int id = 0;
        public int Id
        {
            get { return this.id; }
            set
            {
                if (!(MinId <= value && value <= MaxId))
                    throw new ArgumentOutOfRangeException($"{Id}");

                this.id = value;
            }
        }

        public Student(int id, string name)
        {
            this.Name = name;
            this.Id = id;
        }

        public int CompareTo(Student other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}
