using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloiseLab3
{
    internal class Person : IDateAndCopy, IComparable, IComparer<Person>
    {
        protected string name;
        protected string surname;
        protected DateTime date;
        public Person(string name, string surname, DateTime date)
        {
            this.name = name;
            this.surname = surname;
            this.date = date;
        }
        public Person()
        {
            this.name = "Cherry";
            this.surname = "Cherry";
            this.date = DateTime.Now;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
        public int ChangeDate
        {
            get
            {
                return this.date.Year;
            }
            set
            {
                date = new DateTime(value, date.Month, date.Day);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}\nBirthday: {2}", name, surname, date);
        }

        public virtual string ToShortString()
        {
            return "\n" + "Name: " + name + "\n" + "Surname: " + surname;
        }

        public override bool Equals(object obj) // Переопределить виртуальный метод bool Equals (object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Person objPers = ((Person)obj);
            if (((Person)obj) != null)
            {
                return objPers.name == Name && objPers.surname == Surname && objPers.Date == date;
            }
            return false;
        }

        public override int GetHashCode() // Переопределить виртуальный метод int GetHashCode()
        {
            int hashcode = 0;
            char[] NameChar = Name.ToCharArray();

            foreach (char ch in NameChar)
            {
                hashcode += Convert.ToInt32(ch);
            }
            char[] SurnameChar = Surname.ToCharArray();
            foreach (char ch in SurnameChar)
            {
                hashcode += Convert.ToInt32(ch);
            }
            hashcode += Date.Year * Date.Month;
            return hashcode;
        }

        public static bool operator ==(Person firstPerson, Person secondPerson)
        {
            if (ReferenceEquals(firstPerson, secondPerson))
            {
                return true;
            }
            if ((object)firstPerson == null || (object)secondPerson == null)
            {
                return false;
            }
            return firstPerson.Name == secondPerson.Name && firstPerson.Date == secondPerson.Date && firstPerson.Surname == secondPerson.Surname;
        }
        public static bool operator !=(Person firstPerson, Person secondPerson)
        {
            return !(firstPerson == secondPerson);
        }
        public virtual object DeepCopy() // Метод должен создать полные копии объектов
        {
            Person persCopy = new Person(name, surname, date);
            return persCopy;
        }

        DateTime IDateAndCopy.Date
        {
            get;
            set;
        }

        public int CompareTo(object ob) //System.IComparable для сравнения объектов типа Person по полю с фамилией;
        {
            //return surname.CompareTo(((Person)ob).surname);
            if (surname.CompareTo(((Person)ob).surname) != 0)
            {
                return surname.CompareTo(((Person)ob).surname);
            }
            else
            {
                return 0;
            }
        }

        public int Compare(Person one, Person two) //System.Collections.Generic.IComparer<Person> для сравнения объектов типа Person по дате рождения.
        {
            //return one.Date.CompareTo(two.Date);
            if (one.Date.CompareTo(two.Date) != 0)
            {
                return one.Date.CompareTo(two.Date);
            }
            else
            {
                return 0;
            }
        }
    }
}

