

namespace StructsAndEnums.Structs
{
    using System;
    public struct Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Person(string name, string surname, int age)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }

        public string DisplayInfoAge(int n)
        {
            return this.Age > 0 && this.Age > n ? String.Format($"{Name} {Surname} older than {n}") : String.Format($"{Name} {Surname} younger than {n}");
        }

    }
}
