using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Student : IComparable<Student>
    {
        public Student(int id, string name, Gender gender)
        {
            StudentId = id;
            Name = name;
            gender = gender;
        }

        public int StudentId { get; private set; }

        public string Name { get; private set; }

        public Gender gender { get; private set; }

        public int CompareTo(Student other)
        {
            return StudentId.CompareTo(other.StudentId);
        }
    }
}

