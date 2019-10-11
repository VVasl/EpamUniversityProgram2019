using System;

namespace StructsAndEnums.Structs
{
    public struct Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public string DisplayInfoAge(int n)
        {
            return Age > 0 && Age > n ? String.Format($"{Name} {Surname} older than {n}") : String.Format($"{Name} {Surname} younger than {n}");
        }

    }
}
