namespace SchoolTests
{
    using System;
    using NUnit.Framework;
    using NUnit.Framework.Constraints;
    using School;

    [TestFixture]
    public class Tests
    {
        SchoolAdmissions school;

        [SetUp]
        public void Setup()
        {
            school = new SchoolAdmissions();
        }

        [Test]
        public void TestStudentIdOutOfRangeUpperLimit()
        {
            ActualValueDelegate<object> testDelegate = () => new Student(Student.MaxId, "Ivan");

            Assert.That(testDelegate, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void TestStudentNullName()
        {
            ActualValueDelegate<object> testDelegate = () => new Student(Student.MinId, null);

            Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void TestSchoolDuplicateId()
        {
            Student firstStudent = new Student(Student.MinId, "Ivan");
            Student secondStudent = new Student(Student.MinId, "Maksym");

            school.AddStudent(firstStudent);

            Assert.Throws<ArgumentException>(() => school.AddStudent(secondStudent));
        }
    }
}