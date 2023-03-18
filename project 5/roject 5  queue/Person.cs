using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace roject_5__queue
{
    internal class Person
    {
        public string Name { get; private set; }
        public string SecondName { get; private set; }
        public string ThirdName { get; private set; }
        public string Sex { get; private set; }
        public int Age { get; private set; }
        public double Salary { get; private set; }
        public Person(string name, string secondname,string thirdname, string sex, int age, double salary)
        {
            Name = name;
            SecondName = secondname;
            ThirdName = thirdname;
            Sex = sex;
            Age = age;
            Salary = salary;

        }
        public override string ToString()
        {
            return $"name:{Name} | sex:{Sex} | age:{Age} | salary:{Salary}";
        }


    }
}
